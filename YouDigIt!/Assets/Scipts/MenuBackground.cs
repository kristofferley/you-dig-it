using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackground : MonoBehaviour
{
    public GameObject grass;
    public GameObject dirt;
    public GameObject stone;

    private int gridWidth = 11;
    private int gridHeight = 33;
    private float yStart = 0.45f;
    private float xStart = -5;

    void Start()
    {
        //Creates the hasTile matrix
        bool[][] hasTile = new bool[gridHeight][];
        for (int i = 0; i < gridHeight; i++)
        {
            hasTile[i] = new bool[gridWidth];
            for (int j = 0; j < gridWidth; j++)
            {
                hasTile[i][j] = false;
            }
        }

        //Left stone border
        for (int i = 0; i < gridHeight; i++)
        {
            float yCoord = yStart - i;
            Vector3 position = new(xStart, yCoord, 0);
            Instantiate(stone, position, Quaternion.identity);
            hasTile[i][0] = true;
        }

        //Right stone border
        for (int i = 0; i < gridHeight; i++)
        {
            float yCoord = yStart - i;
            float xCoord = xStart + gridWidth - 1;
            Vector3 position = new(xCoord, yCoord, 0);
            Instantiate(stone, position, Quaternion.identity);
            hasTile[i][gridWidth - 1] = true;
        }

        //Place grass
        for (int j = 1; j < gridWidth - 1; j++)
        {
            float yCoord = yStart - 1;
            float xCoord = xStart + j;
            Vector3 position = new(xCoord, yCoord, 0);
            Instantiate(grass, position, Quaternion.identity);
            hasTile[1][j] = true;
        }

        //Bottom stone border
        for (int j = 1; j < gridWidth - 1; j++)
        {
            float yCoord = yStart - (gridHeight - 1);
            float xCoord = xStart + j;
            Vector3 position = new(xCoord, yCoord, 0);
            Instantiate(stone, position, Quaternion.identity);
            hasTile[gridHeight - 1][j] = true;
        }        

        //Fill the rest with dirt
        for (int i = 0; i < gridHeight; i++)
        {
            for (int j = 0; j < gridWidth; j++)
            {
                if (!hasTile[i][j] && i != 0 && i != gridHeight - 1)
                {
                    float yCoord = yStart - i;
                    float xCoord = xStart + j;
                    Vector3 position = new(xCoord, yCoord, 0);
                    Instantiate(dirt, position, Quaternion.identity);
                }
            }
        }
    }
}
