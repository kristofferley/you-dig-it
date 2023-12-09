using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreatorScript : MonoBehaviour
{
    public GameObject dirt;
    public GameObject grass;
    public GameObject stone;
    public GameObject gold;
    public GameObject purpleGem;
    public GameObject blueGem;
    public GameObject greenGem;
    public GameObject fuel;
    private float yStartCoord = -2.0f;
    private float xStartCoord = -7.5f;    
    private int gridWidth = 13;
    public int gridHeight;
    public int numStones;
    public int numGold;
    public int numFuel;

    void Start()
    {
        bool[][] hasTile = new bool[gridHeight][];
        for (int yPos = 0; yPos < gridHeight; yPos++)
        {
            hasTile[yPos] = new bool[gridWidth];
            for (int xPos = 0; xPos < gridWidth; xPos++)
            {
                hasTile[yPos][xPos] = false;
            }
        }

        for (int xPos = 0; xPos < gridWidth; xPos++)
        {
            float xCoord = xStartCoord + 1.25f * xPos;
            Vector3 position = new(xCoord, yStartCoord, 0);
            Instantiate(grass, position, Quaternion.identity);
            hasTile[0][xPos] = true;
        }

        for (int xPos = 0; xPos < gridWidth; xPos++)
        {
            float yCoord = yStartCoord - 1.25f * (gridHeight - 1);
            float xCoord = xStartCoord + 1.25f * xPos;
            Vector3 position = new(xCoord, yCoord, 0);
            Instantiate(stone, position, Quaternion.identity);
            hasTile[gridHeight - 1][xPos] = true;
        }

        //Place stone
        while (numStones > 0)
        {
            int xRandom = Random.Range(0, gridWidth);
            int yRandom = Random.Range(1, gridHeight - 1);
            if (!hasTile[yRandom][xRandom])
            {
                float xCoord = xStartCoord + 1.25f * xRandom;
                float yCoord = yStartCoord - 1.25f * yRandom;                
                Vector3 position = new(xCoord, yCoord, 0);
                Instantiate(stone, position, Quaternion.identity);
                hasTile[yRandom][xRandom] = true;
                numStones--;
            }            
        }

        //Place gold
        while (numGold > 0)
        {
            int xRandom = Random.Range(0, gridWidth);
            int yRandom = Random.Range(1, gridHeight - 1);            
            if (!hasTile[yRandom][xRandom])
            {
                float xCoord = xStartCoord + 1.25f * xRandom;
                float yCoord = yStartCoord - 1.25f * yRandom;                
                Vector3 position = new(xCoord, yCoord, 0);
                Instantiate(dirt, position, Quaternion.identity);
                Instantiate(gold, position, Quaternion.identity);
                hasTile[yRandom][xRandom] = true;
                numGold--;
            }
        }

        //Place fuel
        while (numFuel > 0)
        {
            int xRandom = Random.Range(0, gridWidth);
            int yRandom = Random.Range(1, gridHeight - 1);            
            if (!hasTile[yRandom][xRandom])
            {
                float xCoord = xStartCoord + 1.25f * xRandom;
                float yCoord = yStartCoord - 1.25f * yRandom;                
                Vector3 position = new(xCoord, yCoord, 0);
                Instantiate(dirt, position, Quaternion.identity);
                Instantiate(fuel, position, Quaternion.identity);
                hasTile[yRandom][xRandom] = true;
                numFuel--;
            }
        }

        //Place purpleGem
        while (true)
        {
            int xRandom = Random.Range(0, gridWidth);
            int yRandom = Random.Range(1, gridHeight - 1);            
            if (!hasTile[yRandom][xRandom])
            {
                float xCoord = xStartCoord + 1.25f * xRandom;
                float yCoord = yStartCoord - 1.25f * yRandom;                
                Vector3 position = new(xCoord, yCoord, 0);
                Instantiate(dirt, position, Quaternion.identity);
                Instantiate(purpleGem, position, Quaternion.identity);
                hasTile[yRandom][xRandom] = true;
                break;
            }
        }

        //Place blueGem
        while (true)
        {
            int xRandom = Random.Range(0, gridWidth);
            int yRandom = Random.Range(1, gridHeight - 1);            
            if (!hasTile[yRandom][xRandom])
            {
                float xCoord = xStartCoord + 1.25f * xRandom;
                float yCoord = yStartCoord - 1.25f * yRandom;                
                Vector3 position = new(xCoord, yCoord, 0);
                Instantiate(dirt, position, Quaternion.identity);
                Instantiate(blueGem, position, Quaternion.identity);
                hasTile[yRandom][xRandom] = true;
                break;
            }
        }

        //Place greenGem
        while (true)
        {
            int xRandom = Random.Range(0, gridWidth);
            int yRandom = Random.Range(1, gridHeight - 1);            
            if (!hasTile[yRandom][xRandom])
            {
                float xCoord = xStartCoord + 1.25f * xRandom;
                float yCoord = yStartCoord - 1.25f * yRandom;                
                Vector3 position = new(xCoord, yCoord, 0);
                Instantiate(dirt, position, Quaternion.identity);
                Instantiate(greenGem, position, Quaternion.identity);
                hasTile[yRandom][xRandom] = true;
                break;
            }
        }

        //Fill the rest with dirt
        for (int yPos = 0; yPos < gridHeight; yPos++)
        {
            for (int xPos = 0; xPos < gridWidth; xPos++)
            {
                if (!hasTile[yPos][xPos])
                {
                    float xCoord = xStartCoord + 1.25f * xPos;
                    float yCoord = yStartCoord - 1.25f * yPos;                    
                    Vector3 position = new(xCoord, yCoord, 0);
                    Instantiate(dirt, position, Quaternion.identity);
                }
            }
        }        
    }
}
