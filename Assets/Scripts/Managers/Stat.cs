using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stat : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public int microWavesCount;
        public int firstEnemyCount;
        public float timeBetweenMicrowaves;
        //public int secondEnemyCount;
        //public int thirdEnemyCount;
    }    

    [System.Serializable]
    public class Level
    {
        public string name;
        public int startMoney;
        public float enemyHealthStrength;
        public Wave[] waves;

        public bool upgrades = false;
        public bool buildings = false;
        public bool ammoTypes = false;
        public bool ammoTypeTwo = false;
        public bool ammoTypeThree = false;

        public Sprite background;
    }

    public Level[] levels;
    public int currentLevelIndex;

    #region Upgrades var
    public int lvl_fireRate = 0;
    public float[] fireRate = {0.5f,0.75f,1f,1.25f,1.5f};

    public int lvl_ammoCapacity = 0;
    public int[] ammoCapacity = {3,4,5,6,7};
    public int currentAmmo;
    public int ammoType = 0;
    public int[] currentAmmoTypes = { 1, 0, 0 };

    public int lvl_speed = 0;
    public float[] speed = {2f,2.5f,3,3.5f,4f};

    public int lvl_reload = 0;
    public float[] reload = {5,4,3,2,1};

    public int lvl_damage = 0;
    public int[] damage = {100, 125, 150, 175, 200};

    public int lvl_tower = 0;
    public int[] towerCount = {1, 2, 3}; 

    public int[] price = { 50, 75, 100, 125, 150, 200, 250, 300, 400, 500 };
    #endregion

    public int money;
    public int gems;
    public int score = 0;

    public int maxHealth = 100;
    public int currentHealth;

    public int currentWave = 0;

    public bool enemyCanAttackObstacles = false;
    public bool respawnAvaible = true;

    private void Awake()
    {
        money = levels[currentLevelIndex].startMoney;
        currentAmmo = 0;
        gems = PlayerPrefs.GetInt("Gems", 0);
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex - 1;
    }
    
    public void AddMoney(int _money)
    {
        money += _money;
    }
    public void AddGems(int _gems)
    {
        gems += _gems;
        PlayerPrefs.SetInt("Gems", gems);
    }
    public void AddScore(int _score)
    {
        score += _score;
    }

    #region Buttons
    public void AmmoTypeOne()
    {
        ammoType = 1;
    }
    public void AmmoTypeTwo()
    {
        ammoType = 2;
    }
    public void AmmoTypeThree()
    {
        ammoType = 3;
    }
    #endregion

    
}
