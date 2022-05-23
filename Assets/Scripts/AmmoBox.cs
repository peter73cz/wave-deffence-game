using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public int minDrop = 1;
    public int maxDrop = 3;

    public float timeForDestroy = 30f;

    Animator animator;
    Stat stat;
    Info info;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        stat = GameObject.Find("GameManager").GetComponent<Stat>();
        info = GameObject.Find("InfoPanel").GetComponent<Info>();
    }

    private void FixedUpdate()
    {
        if (timeForDestroy <= 5) animator.SetTrigger("Destroying");
        if (timeForDestroy <= 0)
        {
            Destroy(gameObject);
        }
        timeForDestroy -= Time.deltaTime;
    }
    void OnMouseDown()
    {
        switch(Random.Range(1,2))
        {
            case 1:
                stat.currentAmmoTypes[1] += Random.Range(minDrop, maxDrop);
                break;
            case 2:
                stat.currentAmmoTypes[2] += Random.Range(minDrop, maxDrop);
                break;
        }
        info.UpdateAmmoButtons();
        Destroy(gameObject);
    }
}
