using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    public Animator animator;

    public SpriteRenderer sr;
    public GameObject sprites;
    public GameObject ammoHolder;

    public GameObject canvas;

    public Rigidbody2D rb;
    public BoxCollider2D colider;

    public bool alive = true;

    Stat stat;
    void Start()
    {
        animator = GetComponent<Animator>();
        stat = GameObject.Find("GameManager").GetComponent<Stat>();
        stat.currentHealth = stat.maxHealth;
    }

    void Update()
    {
        if (stat.currentHealth > stat.maxHealth) stat.currentHealth = stat.maxHealth;
    }
    public void TakeDamage(int damage)
    {
        stat.currentHealth -= damage;

        if (alive)
        {
            // Play hurt animation
            //animator.SetTrigger("Damage");

            if (stat.currentHealth <= 0) Dead();
        }
    }

    public void Respawn()
    {
        animator.SetTrigger("Respawn");  
        gameObject.transform.position = new Vector3(-6, 0, 0);
        sr.enabled = false;
        sprites.SetActive(true);
        stat.currentHealth = stat.maxHealth;
        Invoke("AfterLandRespawn", 3f);
    }
    void AfterLandRespawn()
    {
        colider.enabled = true;
        ammoHolder.SetActive(true);
        alive = true;
    }

    public void Dead()
    {
        //animator.SetBool("IsDead", true);

        sr.enabled = true;
        sprites.SetActive(false);
        ammoHolder.SetActive(false);

        alive = false;
        colider.enabled = false;

        Invoke("OpenRespawnPanel", 2f);
    }

    void OpenRespawnPanel()
    {
        canvas.GetComponent<ClosePanels>().OpenRespawnPanel();
    }
}
