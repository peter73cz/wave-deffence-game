using UnityEngine;
using UnityEngine.UI;

public class RespawnManager : MonoBehaviour
{
    public Animator animator;
    public GameObject player;

    public Button adButton;
    public Button gemButton;

    public int gemsForRespawn = 5;

    void OnEnable()
    {
        if (PlayerPrefs.GetInt("Gems", 0) <= gemsForRespawn) gemButton.interactable = false;
    }

    public void GemsButtonPressed()
    {
        PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems", 0) - gemsForRespawn);
        player.GetComponent<PlayerDamage>().Respawn();
        Close();
    }
    public void AdButtonPressed()
    {
        player.GetComponent<PlayerDamage>().Respawn();
        Close();
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
}
