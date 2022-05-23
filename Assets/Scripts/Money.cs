using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int minMoney = 10;
    public int maxMoney = 20;

    public float timeForDestroy = 30f;

    Animator animator;
    Stat stat;
    GameObject playground;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        stat = GameObject.Find("GameManager").GetComponent<Stat>();
        playground = GameObject.Find("Playground");

        // if (!playground.GetComponent<Collider2D>().bounds.Contains(transform.position));
    }

    private void FixedUpdate()
    {
        if (timeForDestroy <= 5) animator.SetTrigger("Destroying"); 
        if(timeForDestroy <= 0)
        {
            Destroy(gameObject);
        }
        timeForDestroy -= Time.deltaTime;
    }
    void OnMouseDown()
    {
        stat.money += Random.Range(minMoney, maxMoney);
        Destroy(gameObject);
    }
}
