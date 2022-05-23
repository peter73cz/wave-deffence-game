using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    GameObject player;
    GameObject notebook;

    Animator animator;
    Vector3 oldPosition;

    public float speed = 100;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWypoint = 0;
    public bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();

        player = GameObject.Find("Player");
        notebook = GameObject.Find("Notebook");

        target = player.transform;

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p) 
    {
        path = p;
        currentWypoint = 0;
    }

    void FixedUpdate()
    {
        Vector3 motionCheck = 1000 * (transform.position - oldPosition);
        animator.SetInteger("Speed", (int)Mathf.Sqrt((motionCheck.x * motionCheck.x) + (motionCheck.y * motionCheck.y)));
        oldPosition = transform.position;
        //Vector3 nextPosition = new Vector3(transform.position.x + direction.x / 100, transform.position.y + direction.y / 100, 0);
        //transform.position = nextPosition;

        if (player.GetComponent<PlayerDamage>().alive == true) target = player.transform;
        else if (notebook.GetComponent<notebookDamage>().alive == true) target = notebook.transform;
        else target = transform;

        if (path == null) return;

        if (currentWypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWypoint++;
        }
    }
}
