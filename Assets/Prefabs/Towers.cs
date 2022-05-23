using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Towers : MonoBehaviour
{
    Transform spawnPoint;
    Transform goalPoint;

    public void CheckPath()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        foreach (GameObject tower in towers)
        {
            tower.layer = 11;
        }
        AstarPath.active.Scan();

        spawnPoint = GameObject.Find("SpawnPoint").transform;
        goalPoint = GameObject.Find("Player").transform;

        var spawnPointNode = AstarPath.active.GetNearest(spawnPoint.position).node;
        var goalNode = AstarPath.active.GetNearest(goalPoint.position).node;

        if (!PathUtilities.IsPathPossible(spawnPointNode, goalNode))
        {
            foreach (GameObject tower in towers)
            {
                tower.layer = 10;
            }
            AstarPath.active.Scan();
        }
    }
}
