using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public Vector2 position;
    public bool isEmpty;
}

public class Field : MonoBehaviour
{
    public int width = 14, height = 9;
    public float cellSize = 1.5f;
    public List<Cell> self = new List<Cell>(), emptyCells;
    Snake snake;
    // Start is called before the first frame update
    void Start()
    {
        snake = FindObjectOfType<Snake>();
        snake.step = cellSize;
        CreateField();
        SetCells();
    }

    // Update is called once per frame
    void Update()
    {
        if(snake.delta >= snake.stepTime)
        {
            SetCells();
        }
    }
    
    void CreateField()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var cell = new Cell()
                {
                    position = new Vector2(-width / 2f + i * cellSize, -height / 2f + j * cellSize)
                };
                self.Add(cell);
            }
        }
    }

    void SetCells()
    {
        emptyCells = new List<Cell>();
        foreach (var cell in self)
        {
            foreach (var part in snake.bodyParts)
            {
                if((Vector2)part.position == cell.position)
                {
                    cell.isEmpty = false;
                    break;
                } else
                {
                    cell.isEmpty = true;
                }
            }
            if (cell.isEmpty)
            {
                emptyCells.Add(cell);
            }
        }
    }
}
