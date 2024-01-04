using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreatorScript : MonoBehaviour
{
    public GameObject grass;
    public GameObject dirt;
    public GameObject stone;
    public GameObject unpassableBase;
    public GameObject fuel;
    public GameObject gold;
    public GameObject purpleGem;    
    public GameObject greenGem;
    public GameObject blueGem;

    private int gridWidth = 11;
    private int gridHeight = 33;
    private float yStart = 0.45f;
    private float xStart = -5;

    public int numFuel;
    public int numGold;
    public int numStones;

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

        //Bottom stone border
        for (int j = 1; j < gridWidth - 1; j++)
        {
            float yCoord = yStart - (gridHeight - 1);
            float xCoord = xStart + j;
            Vector3 position = new(xCoord, yCoord, 0);
            Instantiate(stone, position, Quaternion.identity);
            hasTile[gridHeight - 1][j] = true;
        }

        //Place grass
        for (int j = 1; j < gridWidth - 1; j++)
        {
            float yCoord = yStart - 1;
            float xCoord = xStart + j;            
            Vector3 position = new(xCoord, yCoord, 0);
            Instantiate(unpassableBase, position, Quaternion.identity);
            Instantiate(grass, position, Quaternion.identity);
            hasTile[1][j] = true;
        }              
        
        //Place stone
        while (numStones > 0)
        {
            int yRandom = Random.Range(2, gridHeight - 1);
            int xRandom = Random.Range(1, gridWidth - 1);
            if (!hasTile[yRandom][xRandom])
            {
                float yCoord = yStart - yRandom;
                float xCoord = xStart + xRandom;
                Vector3 position = new(xCoord, yCoord, 0);
                Instantiate(unpassableBase, position, Quaternion.identity);
                Instantiate(stone, position, Quaternion.identity);
                hasTile[yRandom][xRandom] = true;
                numStones--;
            }
        }

        //Place gold
        while (numGold > 0)
        {
            int yRandom = Random.Range(2, gridHeight - 1);
            int xRandom = Random.Range(1, gridWidth - 1);
            if (!hasTile[yRandom][xRandom])
            {
                float yCoord = yStart - yRandom;
                float xCoord = xStart + xRandom;
                Vector3 position = new(xCoord, yCoord, 0);
                Instantiate(unpassableBase, position, Quaternion.identity);
                Instantiate(dirt, position, Quaternion.identity);
                Instantiate(gold, position, Quaternion.identity);
                hasTile[yRandom][xRandom] = true;
                numGold--;
            }
        }

        //Place fuel
        while (numFuel > 0)
        {
            int yRandom = Random.Range(2, gridHeight - 1);
            int xRandom = Random.Range(1, gridWidth - 1);
            if (!hasTile[yRandom][xRandom])
            {
                float yCoord = yStart - yRandom;
                float xCoord = xStart + xRandom;
                Vector3 position = new(xCoord, yCoord, 0);
                Instantiate(unpassableBase, position, Quaternion.identity);
                Instantiate(dirt, position, Quaternion.identity);
                Instantiate(fuel, position, Quaternion.identity);
                hasTile[yRandom][xRandom] = true;
                numFuel--;
            }
        }

        //Place purpleGem
        while (true)
        {
            int yRandom = Random.Range(2, gridHeight - 1);
            int xRandom = Random.Range(1, gridWidth - 1);
            if (!hasTile[yRandom][xRandom])
            {
                float yCoord = yStart - yRandom;
                float xCoord = xStart + xRandom;
                Vector3 position = new(xCoord, yCoord, 0);
                Instantiate(unpassableBase, position, Quaternion.identity);
                Instantiate(dirt, position, Quaternion.identity);
                Instantiate(purpleGem, position, Quaternion.identity);
                hasTile[yRandom][xRandom] = true;
                break;
            }
        }

        //Place greenGem
        while (true)
        {
            int yRandom = Random.Range(2, gridHeight - 1);
            int xRandom = Random.Range(1, gridWidth - 1);
            if (!hasTile[yRandom][xRandom])
            {
                float yCoord = yStart - yRandom;
                float xCoord = xStart + xRandom;
                Vector3 position = new(xCoord, yCoord, 0);
                Instantiate(unpassableBase, position, Quaternion.identity);
                Instantiate(dirt, position, Quaternion.identity);
                Instantiate(greenGem, position, Quaternion.identity);
                hasTile[yRandom][xRandom] = true;
                break;
            }
        }

        //Place blueGem
        while (true)
        {
            int yRandom = Random.Range(2, gridHeight - 1);
            int xRandom = Random.Range(1, gridWidth - 1);
            if (!hasTile[yRandom][xRandom])
            {
                float yCoord = yStart - yRandom;
                float xCoord = xStart + xRandom;
                Vector3 position = new(xCoord, yCoord, 0);
                Instantiate(unpassableBase, position, Quaternion.identity);
                Instantiate(dirt, position, Quaternion.identity);
                Instantiate(blueGem, position, Quaternion.identity);
                hasTile[yRandom][xRandom] = true;
                break;
            }
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
                    Instantiate(unpassableBase, position, Quaternion.identity);
                    Instantiate(dirt, position, Quaternion.identity);
                }
            }
        }
    }
}
