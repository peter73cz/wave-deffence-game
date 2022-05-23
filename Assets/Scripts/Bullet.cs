using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float[] speeds = {20, 10, 40};
    public Rigidbody2D rb;
    public LayerMask enemyLayers;

    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    Stat stat;

    void Start()
    {
        stat = GameObject.Find("GameManager").GetComponent<Stat>();

        spriteRenderer.sprite = sprites[stat.ammoType];

        rb.velocity = transform.right * speeds[stat.ammoType];
        if (stat.ammoType == 1) StartCoroutine(GameObject.Find("MainCamera").GetComponent<CameraShake>().Kick(0.3f, 0.15f));
        else if(stat.ammoType == 2) StartCoroutine(GameObject.Find("MainCamera").GetComponent<CameraShake>().Kick(0.3f, 0.25f));
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyDamage enemyDamege = collision.GetComponent<EnemyDamage>();
        if (enemyDamege != null)
        {
            switch (stat.ammoType)
            {
                case 0:
                    enemyDamege.TakeDamage(stat.damage[stat.lvl_damage]);
                    Destroy(gameObject);
                    break;
                case 1:
                    StartCoroutine(GameObject.Find("MainCamera").GetComponent<CameraShake>().Shake(0.5f, 1f));

                    // Detect enemies in range
                    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 2, enemyLayers); 
                    // Damage enemies
                    foreach (Collider2D enemy in hitEnemies)
                    {
                        EnemyDamage _enemyDamege = enemy.GetComponent<EnemyDamage>();
                        if (enemyDamege != null) _enemyDamege.TakeDamage(stat.damage[stat.lvl_damage]);
                    }
                    Destroy(gameObject);
                    break;
                case 2:
                    enemyDamege.TakeDamage(stat.damage[stat.lvl_damage]);
                    break;
            }
        }
        if (collision.CompareTag("End"))
        {
            Destroy(gameObject);
        }
    }
}
