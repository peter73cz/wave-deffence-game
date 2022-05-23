using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gems : MonoBehaviour
{
    public Text gemsText;

    void Update()
    {
        gemsText.text = PlayerPrefs.GetInt("Gems", 0).ToString();
    }
}
