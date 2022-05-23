using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class notebookDamage : MonoBehaviour
{
    //public Animator animator;

    //public SpriteRenderer sr;
    public GameObject canvas;
    public BoxCollider2D colider;

    public Slider healthBar;

    public bool alive = true;

    public int maxHealth = 500;
    public int currentHealth;

    Stat stat;
    void Start()
    {
        currentHealth = maxHealth;

        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    void Update()
    {
        if (currentHealth > maxHealth) currentHealth = maxHealth;

        healthBar.value = currentHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (alive)
        {
            if (currentHealth <= 0) Dead();
        }
    }

    public void InstaKill()
    {
        TakeDamage(500);
    }
    public void Dead()
    {
        StartCoroutine(GameObject.Find("MainCamera").GetComponent<CameraShake>().Shake(0.5f, 1f));
        // Destroy
        colider.enabled = false;
        alive = false;

        Invoke("OpenGameOverPanel", 1f);
    }
    void OpenGameOverPanel()
    {
        canvas.GetComponent<ClosePanels>().OpenGameOverPanel();
    }
}
