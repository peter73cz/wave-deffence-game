using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    public GameObject victoryPanel;
    public GameObject nextWaveButton;

    [SerializeField]
    int currentEnemyCount = 0;

    Stat stat;
    void Start()
    {
        stat = GetComponent<Stat>();
    }

    public void AddEnemyCount(int _enemyCount)
    {
        currentEnemyCount += _enemyCount;
    }

    public void OnEnemyDeath()
    {
        currentEnemyCount--;
        if (currentEnemyCount <= 0)
        {
            stat.currentAmmo = stat.ammoCapacity[stat.lvl_ammoCapacity];
            if (stat.currentWave >= stat.levels[stat.currentLevelIndex].waves.Length)
            {
                victoryPanel.SetActive(true);
                victoryPanel.GetComponent<VictoryManager>().Open();

            }
            else nextWaveButton.SetActive(true);

        }
    }
}
