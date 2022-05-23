using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButtons : MonoBehaviour
{
    public void GameSpeedOne()
    {
        Time.timeScale = 1;
    }

    public void GameSpeedTwo()
    {
        Time.timeScale = 2;
    }
}
