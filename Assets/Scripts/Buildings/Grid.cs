using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid {
    private int width;
    private int height;
    private int[,] gridArray;
    private float cellSize;

    public Grid(int _width, int _height, float _cellSize)
    {
        this.width = _width;
        this.height = _height;
        this.cellSize = _cellSize;

        gridArray = new int[width, height];

        for (int i = 0; i < gridArray.GetLength(0); i++)
        {
            for (int j = 0; j < gridArray.GetLength(1); j++)
            {
                UtilsClass.CreateWorldText(gridArray[i, j].ToString(), null, GetWorldPosition(i, j), 20, Color.white, TextAnchor.MiddleCenter);
            }
        }
    }
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }
}
