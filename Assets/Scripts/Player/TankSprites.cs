using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TankSprites : MonoBehaviour
{
    [System.Serializable]
    public class Tanks
    {
        public Sprite body;
        public Sprite tower;
        public int price;
    }
    
    public Tanks[] tanks;

    SpriteRenderer tower;
    SpriteRenderer body;

    private int currentSkin = 0;

    public Button setButton;
    public Button buyButton;
    public Button leftArrow;
    public Button rightArrow;

    public TMP_Text priceText;
    
    public GameObject tankLock;
    Animator lockAnimator;

    void Start()
    {
        lockAnimator = tankLock.GetComponent<Animator>();
        tower = GameObject.Find("Věž").GetComponent<SpriteRenderer>();
        body = GameObject.Find("Trup").GetComponent<SpriteRenderer>();

        PlayerPrefs.SetInt("0", 1);
        currentSkin = PlayerPrefs.GetInt("Skin", 0);
        ChangeSprites();
    }
    void ChangeSprites()
    {
        if (currentSkin == 0) leftArrow.interactable = false;
        else leftArrow.interactable = true;

        if (currentSkin == tanks.Length - 1) rightArrow.interactable = false;
        else rightArrow.interactable = true;

        buyButton.gameObject.SetActive(false);
        setButton.gameObject.SetActive(false);
        setButton.interactable = true;

        if (PlayerPrefs.GetInt($"{currentSkin}", 0) == 1)
        {
            priceText.gameObject.SetActive(false);
            setButton.gameObject.SetActive(true);
            tankLock.SetActive(false);

            if (PlayerPrefs.GetInt("Skin", 0) == currentSkin)
            {
                setButton.interactable = false;
            }
        }
        else
        {
            priceText.gameObject.SetActive(true);
            priceText.text = tanks[currentSkin].price.ToString();

            tankLock.SetActive(true);
            buyButton.gameObject.SetActive(true);
            buyButton.interactable = true;
        }

        tower.sprite = tanks[currentSkin].tower;
        body.sprite = tanks[currentSkin].body;
    }
    public void PreviousSkin()
    {
        if (currentSkin > 0) currentSkin--;
        ChangeSprites();
    }
    public void NextSkin()
    {
        if (currentSkin < tanks.Length - 1) currentSkin++;
        ChangeSprites();
    }
    public void SetSkin()
    {
        PlayerPrefs.SetInt("Skin", currentSkin);
        ChangeSprites();
    }
    public void BuySkin()
    {
        if (PlayerPrefs.GetInt("Gems", 0) >= tanks[currentSkin].price)
        {
            lockAnimator.SetBool("IsUnlocked", true);
            buyButton.interactable = false;
            PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems", 0) - tanks[currentSkin].price);
            PlayerPrefs.SetInt($"{currentSkin}", 1);
            Invoke("ChangeSprites", 2f);
        }
    }
}
