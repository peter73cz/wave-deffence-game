using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public GameObject[] buildings;
    BuildingPlacement buildingPlacement;

    Stat stat;

    void Start()
    {
        buildingPlacement = GetComponent<BuildingPlacement>();
        stat = GameObject.Find("GameManager").GetComponent<Stat>();
    }

    public void PickBuilding(int number)
    {
        if (GameObject.FindGameObjectsWithTag("Tower").Length < stat.towerCount[stat.lvl_tower] && stat.money >= 100)
        {
            Instantiate(buildings[number], new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
