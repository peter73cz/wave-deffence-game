using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDamage : MonoBehaviour
{
    public int health = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = health;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
            // Play hurt animation
            //animator.SetTrigger("Damage");


            if (currentHealth <= 0)
            {
                //animator.SetBool("IsDead", true);       // Play Dead animation
                //animator.SetTrigger("Dead");
                Destroy(gameObject);
                GameObject.Find("GameManager").GetComponentInChildren<Towers>().CheckPath();
            }
    }
}
