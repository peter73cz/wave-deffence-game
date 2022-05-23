using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoHolder : MonoBehaviour
{
    public GameObject ammoPrefab;
    List<GameObject> ammoes = new List<GameObject>();
    Stat stat;

    public float rozsah = 1f;
    float i = 0;
    public int numberOfAmmo = 0;

    void Start()
    {
        stat = GameObject.Find("GameManager").GetComponent<Stat>();
    }

    private void Update()
    {
        if (stat.ammoCapacity[stat.lvl_ammoCapacity] > numberOfAmmo)
        {
            numberOfAmmo++;
            AddAmmoSprite();
        }


    }

    public void AddAmmoSprite()
    {
        Instantiate(ammoPrefab, transform);

        i = -((float)(numberOfAmmo - 1) / 2 * rozsah);

        foreach (Transform child in transform)
        {
            child.position = new Vector2(transform.position.x + i, transform.position.y);

            i += rozsah;

            ammoes.Clear();
        }
    }
}
