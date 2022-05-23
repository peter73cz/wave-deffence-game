using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanels : MonoBehaviour
{
    public GameObject respawnPanel;
    private bool respawn = false;
    public GameObject pausePanel;
    private bool pause = false;
    public GameObject victoryPanel;
    private bool victory = false;
    public GameObject gameOverPanel;
    private bool gameOver = false;

    public bool CloseAllPanels()
    {
        if (respawn)
        {
            respawnPanel.GetComponent<RespawnManager>().Close();
            respawn = false;
            return true;
        }
        else if (pause)
        {
            pausePanel.GetComponent<PauseManager>().Close();
            pause = false;
            return true;
        }
        else if (victory)
        {
            victoryPanel.GetComponent<VictoryManager>().Close();
            victory = false;
            return true;
        }
        else if (gameOver)
        {
            gameOverPanel.GetComponent<GameOverManager>().Close();
            gameOver = false;
            return true;
        }
        else return false;
    }

    public void OpenRespawnPanel()
    {
        var stat = GameObject.Find("GameManager").GetComponent<Stat>();
        if (stat.respawnAvaible == true)
        {
            stat.respawnAvaible = false;
            if (CloseAllPanels()) Invoke("TurnOnRespawnPanel", .6f);
            else TurnOnRespawnPanel();
        }
        else GameObject.Find("Notebook").GetComponent<notebookDamage>().InstaKill();
    }
    void TurnOnRespawnPanel()
    {
        respawn = true;
        respawnPanel.SetActive(true);
        respawnPanel.GetComponent<RespawnManager>().Open();
    }

    public void OpenPausePanel()
    {
        if (CloseAllPanels()) Invoke("TurnOnPausePanel", .6f);
        else TurnOnPausePanel();
    }
    void TurnOnPausePanel()
    {
        pause = true;
        pausePanel.SetActive(true);
        pausePanel.GetComponent<PauseManager>().Open();
    }

    public void OpenVictoryPanel()
    {
        if (CloseAllPanels()) Invoke("TurnOnVictoryPanel", .6f);
        else TurnOnVictoryPanel();
    }
    void TurnOnVictoryPanel()
    {
        victory = true;
        victoryPanel.SetActive(true);
        victoryPanel.GetComponent<VictoryManager>().Open();
    }

    public void OpenGameOverPanel()
    {
        if (CloseAllPanels()) Invoke("TurnOnGameOverPanel", .6f);
        else TurnOnGameOverPanel();
    }
    void TurnOnGameOverPanel()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        gameOverPanel.GetComponent<GameOverManager>().Open();
    }
}
