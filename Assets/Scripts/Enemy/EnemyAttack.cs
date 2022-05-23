using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 1f;
    public float attackRate = 0.2f;
    public int attackDamage = 10;

    float nextAttackTime = 0f;

    LayerMask player;
    LayerMask obstacle;
    LayerMask notebook;

    Collider2D colider;
    Animator animator;

    Stat stat;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        player = LayerMask.GetMask("Player");
        obstacle = LayerMask.GetMask("Attackable");
        notebook = LayerMask.GetMask("Notebook");

        stat = GameObject.Find("GameManager").GetComponent<Stat>();
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            colider = Physics2D.OverlapCircle(transform.position, attackRange, obstacle);
            if (colider != null)
            { 
                animator.SetTrigger("Attack");
                StartCoroutine(Attack("Tower",colider));
                nextAttackTime = Time.time + 1f / (attackRate * 2);
                return;
            }
            colider = Physics2D.OverlapCircle(transform.position, attackRange, player);
            if (colider != null)
            {
                animator.SetTrigger("Attack");
                StartCoroutine(Attack("Player",colider));
                nextAttackTime = Time.time + 1f / (attackRate * 2);
                return;
            }
            colider = Physics2D.OverlapCircle(transform.position, attackRange, notebook);
            if (colider != null)
            {
                animator.SetTrigger("Attack");
                StartCoroutine(Attack("Notebook",colider));
                nextAttackTime = Time.time + 1f / (attackRate * 2);
                return;
            }


        }
    }
    IEnumerator Attack(string enemyType, Collider2D colider)
    {
        yield return new WaitForSeconds(0.5f);

        switch (enemyType)
        {
            case "Tower":
                colider.GetComponent<TowerDamage>().TakeDamage(attackDamage);
                break;
            case "Player":
                colider.GetComponent<PlayerDamage>().TakeDamage(attackDamage);
                break;
            case "Notebook":
                colider.GetComponent<notebookDamage>().TakeDamage(attackDamage);
                break;
        }
    }
}
