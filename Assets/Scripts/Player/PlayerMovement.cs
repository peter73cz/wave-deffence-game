using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public Transform Player;
    Stat stat;

    public Joystick joystick;
    public AudioSource sound;

    
    bool isPlaying = false;

    public Collider2D playground;

    void Start()
    {
        stat = GameObject.Find("GameManager").GetComponent<Stat>();
    }

    void Update()
    {
        if (playground.bounds.Contains(new Vector3(transform.position.x + (0.5f * Mathf.Sign(joystick.Horizontal)), transform.position.y))) transform.Translate(Vector3.right * stat.speed[stat.lvl_speed] * joystick.Horizontal * Time.deltaTime);
        if (playground.bounds.Contains(new Vector3(transform.position.x, transform.position.y + (0.5f * Mathf.Sign(joystick.Vertical))))) transform.Translate(Vector3.up * stat.speed[stat.lvl_speed] * joystick.Vertical * Time.deltaTime);

        if (joystick.Horizontal == 0)
        {
            animator.SetBool("IsMoveing", false);
            FindObjectOfType<AudioManager>().Stop("TankMove");
            isPlaying = false;
        }
        else
        {
            animator.SetBool("IsMoveing", true);

            if (!isPlaying)
            {
                FindObjectOfType<AudioManager>().Play("TankMove");
                isPlaying = true;
            }
        }
        animator.SetFloat("Speed", joystick.Horizontal);

        /*
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * stat.speed[stat.lvl_speed] * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * stat.speed[stat.lvl_speed] * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * stat.speed[stat.lvl_speed] * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * stat.speed[stat.lvl_speed] * Time.deltaTime);
        }
        */
    }
}
