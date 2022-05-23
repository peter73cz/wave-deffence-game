using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    [System.Serializable]
    public class Sprites
    {
        public Sprite normal;
        public Sprite pressed;
        public Sprite empty;
    }

    public Text waveText;
    public Text moneyText;
    public Text scoreText;
    // public Text buildPriceText;
    public Text[] ammoTexts;

    public Image lifeBar;
    public Image reloadBar;

    Stat stat;

    public Button[] upgradeButtons;
    bool upgadeButtonActive = true;
    bool buildButtonActive = true;
    public Button[] ammoButtons;
    bool ammoButtonsActice = true;
    bool thirdAmmoButton = true;
    public Sprites[] sprites;

    public GameObject pausePanel;

    float currentTime = 0;

    void Start()
    {
        stat = GameObject.Find("GameManager").GetComponent<Stat>();

        if (stat.levels[stat.currentLevelIndex].ammoTypes != ammoButtonsActice)
        {
            ammoButtons[0].gameObject.SetActive(false);
            ammoButtons[1].gameObject.SetActive(false);
            ammoButtonsActice = false;
        }
        if (stat.levels[stat.currentLevelIndex].ammoTypeThree != thirdAmmoButton)
        {
            ammoButtons[2].gameObject.SetActive(false);
            thirdAmmoButton = false;
        }
        if (stat.levels[stat.currentLevelIndex].upgrades != upgadeButtonActive)
        {
            upgradeButtons[0].gameObject.SetActive(false);
            upgadeButtonActive = false;
        }
        if (stat.levels[stat.currentLevelIndex].buildings != buildButtonActive)
        {
            upgradeButtons[1].gameObject.SetActive(false);
            buildButtonActive = false;
        }

        UpdateAmmoButtons();
    }

    void Update()
    {
        waveText.text = $"{stat.currentWave}/{stat.levels[stat.currentLevelIndex].waves.Length}";
        moneyText.text = $"{stat.money}Kč";
        scoreText.text = $"Score: {stat.score}";

        lifeBar.fillAmount = (float)stat.currentHealth / (float)stat.maxHealth;
        if (Time.time - currentTime <= stat.reload[stat.lvl_reload]) reloadBar.fillAmount = (Time.time - currentTime) / (float)stat.reload[stat.lvl_reload];
        else reloadBar.fillAmount = 1f;

        
        if (ammoButtonsActice)
        {
            ammoTexts[0].text = "∞";
            for (int i = 1; i < 3; i++)
            {
                ammoTexts[i].text = stat.currentAmmoTypes[i].ToString();
            }
        }

        if (buildButtonActive)
        {
            if (GameObject.FindGameObjectWithTag("Prefab") == null && GameObject.FindGameObjectsWithTag("Tower").Length < stat.towerCount[stat.lvl_tower] && stat.money >= 100) upgradeButtons[1].interactable = true;
            else upgradeButtons[1].interactable = false;
        }
    }

    public void StartReloading()
    {
        currentTime = Time.time;
    }
    public void AmmoButtonPressed(int _buttonNumber)
    {
        stat.ammoType = _buttonNumber;
        UpdateAmmoButtons();
    }
    public void UpdateAmmoButtons()
    {
        if (stat.currentAmmoTypes[stat.ammoType] <= 0) stat.ammoType = 0;

        for (int i = 0; i < 3; i++)
        {
            if(stat.currentAmmoTypes[i] <= 0)
            {
                ammoButtons[i].GetComponent<Image>().sprite = sprites[i].empty;
                ammoButtons[i].interactable = false;
            }
            else
            {
                ammoButtons[i].interactable = true;

                if (i == stat.ammoType) ammoButtons[i].GetComponent<Image>().sprite = sprites[i].pressed;
                else ammoButtons[i].GetComponent<Image>().sprite = sprites[i].normal;
            }
        }
    }

    public void PauseButtonPressed()
    {
        pausePanel.SetActive(true);
        pausePanel.GetComponent<PauseManager>().Open();
    }
}
