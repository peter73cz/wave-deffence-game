using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    WaveSpawner waveSpawner;
    Stat stat;
    EnemyChecker enemyChecker;


    private void Start()
    {
        waveSpawner = GetComponent<WaveSpawner>();
        stat = GetComponent<Stat>();
        enemyChecker = GetComponent<EnemyChecker>();

        NextWave();
    }

    public void NextWave()
    {
        enemyChecker.AddEnemyCount(stat.levels[stat.currentLevelIndex].waves[stat.currentWave].firstEnemyCount * stat.levels[stat.currentLevelIndex].waves[stat.currentWave].microWavesCount);
        waveSpawner.WaveSpawning(stat.levels[stat.currentLevelIndex].waves[stat.currentWave].firstEnemyCount);
    }
}
