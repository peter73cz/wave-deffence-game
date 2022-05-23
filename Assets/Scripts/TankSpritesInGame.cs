using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpritesInGame : MonoBehaviour
{
    public Sprite[] bodyes;
    public Sprite[] towers;
    public SpriteRenderer tower;
    public SpriteRenderer body;

    void Start()
    {
        tower.sprite = towers[PlayerPrefs.GetInt("Skin", 0)];
        body.sprite = bodyes[PlayerPrefs.GetInt("Skin", 0)];
    }
}
