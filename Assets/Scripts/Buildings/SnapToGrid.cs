using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    public float grid = 1;
    private float x = 0, y = 0;
    void Start()
    {
        
    }

    void Update()
    {
        if (grid > 0)
        {
            float reciprocalGrid = 1f / grid;
            x = Mathf.Round(transform.position.x * reciprocalGrid) / reciprocalGrid;
            y = Mathf.Round(transform.position.y * reciprocalGrid) / reciprocalGrid;
            
            transform.position = new Vector2(x, y);
        }
    }
}
