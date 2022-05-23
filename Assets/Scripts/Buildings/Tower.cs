using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Tower : MonoBehaviour
{
    public void Awake()
    {
        GameObject.Find("GameManager").GetComponentInChildren<Towers>().CheckPath();
    }
    
}
