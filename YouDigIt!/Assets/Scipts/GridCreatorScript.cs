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
    private int gridHeight = 32;
    private int gridWidth = 13;
    private int numStones = 10;
    private int numGold = 10;
    private int numFuel = 10;

    void Start()
    {
        bool[][] hasTile = new bool[gridHeight][];
        for (int k = 0; k < gridHeight; k++)
        {
            hasTile[k] = new bool[gridWidth];
        }

        //Place stone
        while (numStones > 0)
        {
            int yRandom = Random.Range(0, gridHeight);
            int xRandom = Random.Range(0, gridWidth);
            if (!hasTile[yRandom][xRandom])
            {
                Vector3 position = new(yRandom, xRandom, 0);
                Instantiate(stone, position, Quaternion.identity);
                hasTile[yRandom][xRandom] = true;
                numStones--;
            }            
        }

        //Place gold
        while (numGold > 0)
        {
            int yRandom = Random.Range(0, gridHeight);
            int xRandom = Random.Range(0, gridWidth);
            if (!hasTile[yRandom][xRandom])
            {
                Vector3 position = new(yRandom, xRandom, 0);
                Instantiate(dirt, position, Quaternion.identity);
                Instantiate(gold, position, Quaternion.identity);
                hasTile[yRandom][xRandom] = true;
                numGold--;
            }
        }

        //Place fuel
        while (numFuel > 0)
        {
            int yRandom = Random.Range(0, gridHeight);
            int xRandom = Random.Range(0, gridWidth);
            if (!hasTile[yRandom][xRandom])
            {
                Vector3 position = new(yRandom, xRandom, 0);
                Instantiate(dirt, position, Quaternion.identity);
                Instantiate(fuel, position, Quaternion.identity);
                hasTile[yRandom][xRandom] = true;
                numFuel--;
            }
        }

        //Place purpleGem
        while (true)
        {
            int yRandom = Random.Range(0, gridHeight);
            int xRandom = Random.Range(0, gridWidth);
            if (!hasTile[yRandom][xRandom])
            {
                Vector3 position = new(yRandom, xRandom, 0);
                Instantiate(dirt, position, Quaternion.identity);
                Instantiate(purpleGem, position, Quaternion.identity);
                hasTile[yRandom][xRandom] = true;
                break;
            }
        }

        //Place blueGem
        while (true)
        {
            int yRandom = Random.Range(0, gridHeight);
            int xRandom = Random.Range(0, gridWidth);
            if (!hasTile[yRandom][xRandom])
            {
                Vector3 position = new(yRandom, xRandom, 0);
                Instantiate(dirt, position, Quaternion.identity);
                Instantiate(blueGem, position, Quaternion.identity);
                hasTile[yRandom][xRandom] = true;
                break;
            }
        }

        //Place greenGem
        while (true)
        {
            int yRandom = Random.Range(0, gridHeight);
            int xRandom = Random.Range(0, gridWidth);
            if (!hasTile[yRandom][xRandom])
            {
                Vector3 position = new(yRandom, xRandom, 0);
                Instantiate(dirt, position, Quaternion.identity);
                Instantiate(greenGem, position, Quaternion.identity);
                hasTile[yRandom][xRandom] = true;
                break;
            }
        }

        //Fill the rest with dirt
        for (int i = 0; i < gridHeight; i++)
        {
            for (int j = 0; j < gridWidth; j++)
            {
                if (!hasTile[j][i])
                {
                    Vector3 position = new(j, i, 0);
                    Instantiate(dirt, position, Quaternion.identity);
                }
            }
        }        
    }
}
