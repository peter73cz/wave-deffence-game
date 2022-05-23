using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelector : MonoBehaviour
{
    public Button prefab;

    int numberOfLevels;
    int levelReached = 1;

    void Start()
    {
        numberOfLevels = SceneManager.sceneCountInBuildSettings - 1;

        for (int i = 0; i < numberOfLevels; i++)
        {
            Instantiate(prefab, transform);
        }

        Button[] buttons = this.GetComponentsInChildren<Button>();

        levelReached = PlayerPrefs.GetInt("LevelReached", 0);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInChildren<TMP_Text>().text = (i + 1).ToString();

            //buttons[i].GetComponent<level_button_new>().LevelText.text = i.ToString();
            // buttons[i].onClick.AddListener(() => LoadLevel("Level" + (i + 1).ToString()));

            if (i > levelReached)
            {
                buttons[i].interactable = false;
            }    
        }
        foreach (Button btn in buttons)
        {
            
            btn.onClick.AddListener(() => LoadLevel("Level" + btn.GetComponentInChildren<TMP_Text>().text));
        }
    }

    void LoadLevel(string value)
    {
        SceneManager.LoadScene(value);
    }
}
