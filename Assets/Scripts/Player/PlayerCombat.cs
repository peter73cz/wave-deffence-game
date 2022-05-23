using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;

    float nextAttackTime = 0f;
    bool isReloading = false;

    public GameObject bulletPrefab;
    Stat stat;

    public Button shotButton;
    public Button reloadButton;

    public Info info;

    public static PlayerCombat instace;

    void Start()
    {
        instace = this;
        stat = GameObject.Find("GameManager").GetComponent<Stat>();

        ReloadButton();
    }

    public void ShotButton()
    {
        if (Time.time >= nextAttackTime)
        {
                if (stat.currentAmmo > 0) Shot();
                else
                {
                    FindObjectOfType<AudioManager>().Play("Empty");
                    if (PlayerPrefs.GetInt("AutoReload", 1) == 1) Invoke("ReloadButton", 0.5f);
                }
        }
    }    
    public void ReloadButton()
    {
        if (!isReloading)
        {
            shotButton.interactable = false;
            reloadButton.interactable = false;

            isReloading = true;

            FindObjectOfType<AudioManager>().Play("Reload");

            info.StartReloading();
            Invoke("Reload", stat.reload[stat.lvl_reload]);
        }
    }

    void Shot()
    {
        FindObjectOfType<AudioManager>().Play("Shot");

        Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
        stat.currentAmmo--;
        if (stat.ammoType != 0)
        {
            stat.currentAmmoTypes[stat.ammoType]--;
            info.UpdateAmmoButtons();
        }

        nextAttackTime = Time.time + 1f/( stat.fireRate[stat.lvl_fireRate] * 2);
    }

    void Reload()
    {
        stat.currentAmmo = stat.ammoCapacity[stat.lvl_ammoCapacity];
        isReloading = false;
        shotButton.interactable = true;
        reloadButton.interactable = true;
    }
}
