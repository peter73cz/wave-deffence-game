using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour 
{
    int levelAmount;
    private int currentLevel;

    private void Start()
    {
        levelAmount = SceneManager.sceneCount - 1;
        CheckLevel();   
    }

    void CheckLevel()
    {
        for (int i = 1; i <= levelAmount; i++)
        {
            if (SceneManager.GetActiveScene().name == "Level" + i)
            {
                currentLevel = i;
                SaveGame();
            }
        }
    }

    void SaveGame()
    {
            PlayerPrefs.SetInt("LevelReached", currentLevel);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
