using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;
    Stat stat;

    public GameObject nextWaveButon;

    private void Start()
    {
        stat = GetComponent<Stat>();
    }
    public void WaveSpawning(int enemies)
    {
        nextWaveButon.SetActive(false);

        stat.currentWave++;

        StartCoroutine(spawnWave(enemies));
    }

    IEnumerator spawnWave(int _enemies)
    {
        for (int i = 0; i < stat.levels[stat.currentLevelIndex].waves[stat.currentWave - 1].microWavesCount; i++)
        {
            for (int j = 0; j < _enemies; j++)
            {
                spawnEnemy();
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForSeconds(stat.levels[stat.currentLevelIndex].waves[stat.currentWave - 1].timeBetweenMicrowaves);
        }
    }

    void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position - new Vector3(0,Random.Range(-5,5) / 2f), spawnPoint.rotation);
    }
}
