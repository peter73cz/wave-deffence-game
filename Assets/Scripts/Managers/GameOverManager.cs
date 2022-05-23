using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public Animator animator;
    Stat stat;

    public Text score;

    private void OnEnable()
    {
        stat = GameObject.Find("GameManager").GetComponent<Stat>();
        PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems", 0) + (stat.score / 1000));
        score.text = $"Score: {stat.score}";
    }

    public void Open()
    {
        animator.SetBool("IsOpen", true);
    }
    public void Close()
    {
        animator.SetBool("IsOpen", false);
        Invoke("TurnOff", .6f);
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
