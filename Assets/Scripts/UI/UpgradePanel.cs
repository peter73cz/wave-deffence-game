using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    Animator animator;
    public GameObject panel;

    private void Start()
    {
        animator = panel.GetComponent<Animator>();
    }

    public void OpenButton()
    {
        panel.SetActive(true);
        Open();
    }

    public void CloseButton()
    {
        Time.timeScale = 1;
        animator.SetBool("IsOpen", false);
        Invoke("Close", .6f);
    }

    void Open()
    {
        animator.SetBool("IsOpen", true);
        Invoke("StopTime", .5f);
    }
    void Close()
    {
        panel.SetActive(false);
    }

    void StopTime()
    {
        Time.timeScale = 0;
    }
}
