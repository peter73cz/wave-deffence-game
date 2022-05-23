using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class HomeScreen : MonoBehaviour
{
    public Light2D lighting;

    float jas = 0f;
    float jasnost = 0f;

    private void FixedUpdate()
    {
        if (jas == jasnost)
        {

            jasnost = Random.Range(80 , 120);
        }

        lighting.intensity = jas / 100;

        if (jas < jasnost) jas++;
        else jas--;
    }
}
