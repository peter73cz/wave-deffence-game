using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public Animator animator;


    public void Open()
    {
        animator.SetBool("IsOpen", true);
        Invoke("Pause", 0.6f);
    }

    public void Close()
    {
        Time.timeScale = 1;
        animator.SetBool("IsOpen", false);
        Invoke("TurnOff", .6f);
    }

    void Pause()
    {
        Time.timeScale = 0;
    }
    void TurnOff()
    {
        gameObject.SetActive(false);
    }

    public void RestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void HomeButtonPressed()
    {
        SceneManager.LoadScene("Menu");
    }
}
