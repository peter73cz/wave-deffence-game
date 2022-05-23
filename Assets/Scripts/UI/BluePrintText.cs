using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BluePrintText : MonoBehaviour
{ 
    public TMP_Text fireRateText;
    public TMP_Text ammoText;
    public TMP_Text reloadText;
    public TMP_Text speedText;
    public TMP_Text damageText;
    public TMP_Text towerText;

    public Button fireRateButton;
    public Button ammoButton;
    public Button reloadButton;
    public Button speedButton;
    public Button damageButton;
    public Button towerButton;

    public TMP_Text atributesText;
    public TMP_Text infoText;

    Stat stat;

    private void Start()
    {
        stat = GameObject.Find("GameManager").GetComponent<Stat>();

        UpdateText();
    }

    void Update()
    {
        atributesText.text =
            $"Fire Rate: \n" +
            $"Ammo: \n" +
            $"Reload speed: \n" +
            $"Tank speed: \n" +
            $"Bullet damage: \n" +
            $"Max towers: \n"
            ;
        infoText.text =
            $"{stat.fireRate[stat.lvl_fireRate]} \n" +
            $"{stat.ammoCapacity[stat.lvl_ammoCapacity]} \n" +
            $"{stat.reload[stat.lvl_reload]} s \n" +
            $"{stat.speed[stat.lvl_speed]} Km/h \n" +
            $"{stat.damage[stat.lvl_damage]} \n" +
            $"{stat.towerCount[stat.lvl_tower]} \n"
            ;
    }

    #region Upgrades
    public void AddFireRate()
    {
        if (stat.lvl_fireRate < stat.fireRate.Length - 1 && stat.money >= stat.price[stat.lvl_fireRate])
        {
            stat.money -= stat.price[stat.lvl_fireRate];
            stat.lvl_fireRate++;

            UpdateText();
        }
    }
    public void AddAmmoCapacity()
    {
        if (stat.lvl_ammoCapacity < stat.ammoCapacity.Length - 1 && stat.money >= stat.price[stat.lvl_ammoCapacity])
        {
            stat.money -= stat.price[stat.lvl_ammoCapacity];
            stat.lvl_ammoCapacity++;
            stat.currentAmmo++;

            UpdateText();
        }
    }
    public void AddSpeed()
    {
        if (stat.lvl_speed < stat.speed.Length - 1 && stat.money >= stat.price[stat.lvl_speed])
        {
            stat.money -= stat.price[stat.lvl_speed];
            stat.lvl_speed++;

            UpdateText();
        }
    }

    public void AddReload()
    {
        if (stat.lvl_reload < stat.reload.Length - 1 && stat.money >= stat.price[stat.lvl_reload])
        {
            stat.money -= stat.price[stat.lvl_reload];
            stat.lvl_reload++;

            UpdateText();
        }
    }

    public void AddDamage()
    {
        if (stat.lvl_damage < stat.damage.Length - 1 && stat.money >= stat.price[stat.lvl_damage])
        {
            stat.money -= stat.price[stat.lvl_damage];
            stat.lvl_damage++;

            UpdateText();
        }
    }

    public void AddTower()
    {
        if (stat.lvl_tower < stat.towerCount.Length - 1 && stat.money >= stat.price[stat.lvl_tower])
        {
            stat.money -= stat.price[stat.lvl_tower];
            stat.lvl_tower++;

            UpdateText();
        }
    }
    #endregion

    public void UpdateText()
    {
        if (stat.lvl_fireRate + 1 < stat.fireRate.Length)
        {
            fireRateText.text = $"LVL {stat.lvl_fireRate + 1}.";
            fireRateButton.GetComponentInChildren<Text>().text = stat.price[stat.lvl_fireRate].ToString();
        }
        else
        {
            fireRateButton.gameObject.SetActive(false);
            fireRateText.text = "Max LVL";
        }

        if (stat.lvl_ammoCapacity + 1 < stat.ammoCapacity.Length)
        {
            ammoText.text = $"LVL {stat.lvl_ammoCapacity + 1}.";
            ammoButton.GetComponentInChildren<Text>().text = stat.price[stat.lvl_ammoCapacity].ToString();
        }
        else
        {
            ammoButton.gameObject.SetActive(false);
            ammoText.text = "Max LVL";
        }

        if (stat.lvl_reload + 1 < stat.reload.Length)
        {
            reloadText.text = $"LVL {stat.lvl_reload + 1}.";
            reloadButton.GetComponentInChildren<Text>().text = stat.price[stat.lvl_reload].ToString();
        }
        else
        {
            reloadButton.gameObject.SetActive(false);
            reloadText.text = "Max LVL";
        }

        if (stat.lvl_speed + 1 < stat.speed.Length)
        {
            speedText.text = $"LVL {stat.lvl_speed + 1}.";
            speedButton.GetComponentInChildren<Text>().text = stat.price[stat.lvl_speed].ToString();
        }
        else
        {
            speedButton.gameObject.SetActive(false);
            speedText.text = "Max LVL";
        }

        if (stat.lvl_damage + 1 < stat.damage.Length)
        {
            damageText.text = $"LVL {stat.lvl_damage + 1}.";
            damageButton.GetComponentInChildren<Text>().text = stat.price[stat.lvl_damage].ToString();
        }
        else
        {
            damageButton.gameObject.SetActive(false);
            damageText.text = "Max LVL";
        }

        if (stat.lvl_tower + 1 < stat.towerCount.Length)
        {
            towerText.text = $"LVL {stat.lvl_tower + 1}.";
            towerButton.GetComponentInChildren<Text>().text = stat.price[stat.lvl_tower].ToString();
        }
        else
        {
            towerButton.gameObject.SetActive(false);
            towerText.text = "Max LVL";
        }
    }
}
