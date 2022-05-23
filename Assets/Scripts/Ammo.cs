using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public SpriteRenderer sprite;
    int ammoNumber;
    Stat stat;

    void Awake()
    {
        ammoNumber = transform.parent.GetComponent<AmmoHolder>().numberOfAmmo;
        stat = GameObject.Find("GameManager").GetComponent<Stat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ammoNumber > stat.currentAmmo) sprite.color = new Color(1f, 1f, 1f, 0.5f);
        else sprite.color = new Color(1f, 1f, 0f, 1f);
    }
}
