using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    Animator animator;

    public EnemyAttack enemyAttack;
    public EnemyMovement enemyMovement;

    public Rigidbody2D rb;
    public Collider2D colider;
    public Collider2D bodyCollider;

    public Transform moneyPrefab;
    public Transform ammoPrefab;

    public int respawnDelay = 5;
    public float maxHealth = 10;
    private float currentHealth;
    bool alive = true;

    public int point = 100;
    public float dropRate = 0.25f;

    Stat stat;

    void Start()
    {
        stat = GameObject.Find("GameManager").GetComponent<Stat>();
        animator = GetComponentInChildren<Animator>();

        maxHealth *= stat.levels[stat.currentLevelIndex].enemyHealthStrength;
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (alive)
        {
            // Play hurt animation
            //animator.SetTrigger("Damage");
            
            if (currentHealth <= 0)
            {
                animator.SetTrigger("Dead");
                alive = false;
                rb.bodyType = RigidbodyType2D.Static;
                colider.enabled = false;
                bodyCollider.enabled = false;
                enemyAttack.enabled = false;
                enemyMovement.enabled = false;
                GameObject.Find("GameManager").GetComponent<EnemyChecker>().OnEnemyDeath();
                Invoke("Dead", respawnDelay); 
                stat.AddScore(point);                           
            }
        }
    }

    public void Dead()
    {
        Debug.Log("Destroing enemy.");
        Destroy(gameObject);
            if (Random.Range(0f, 1f) <= dropRate)
                Instantiate(moneyPrefab, new Vector2(transform.position.x + 1, transform.position.y), this.transform.rotation);
            else if (stat.levels[stat.currentLevelIndex].ammoTypeThree && Random.Range(0f, 1f) <= dropRate && stat.levels[stat.currentLevelIndex].ammoTypes)
                Instantiate(ammoPrefab, new Vector2(transform.position.x + 1, transform.position.y), this.transform.rotation);
    }
}
