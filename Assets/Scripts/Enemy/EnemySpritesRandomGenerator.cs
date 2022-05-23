using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpritesRandomGenerator : MonoBehaviour
{
    public GameObject[] heads;
    public GameObject box;

    public GameObject body;
    public GameObject backHand;
    public GameObject frontHand;

    void Start()
    {
        if (Random.Range(0, 100) < 80) box.SetActive(false);
        if (Random.Range(0, 100) > 50) heads[0].SetActive(false);
        else heads[1].SetActive(false);

        Color color;
        if (Random.Range(0,100) > 50)
        {
            color = new Color(0.5f, 0.8f, 0.8f);
        }
        else if (Random.Range(0, 100) > 50)
        {
            color = new Color(1f, 0.6f, 0.6f);
        }
        else
        {
            color = new Color(0.3f, 0.8f, 0.3f);
        }

        body.GetComponent<SpriteRenderer>().color = color;
        backHand.GetComponent<SpriteRenderer>().color = color;
        frontHand.GetComponent<SpriteRenderer>().color = color;
    }
}
