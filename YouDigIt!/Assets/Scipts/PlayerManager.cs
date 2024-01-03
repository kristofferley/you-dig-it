using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;

    void Start()
    {        
        ScoreTrackerScript.latestScore = 0;
        GemTrackerScript.latestGems = 0;
        FuelTrackerScript.latestFuel = 20;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-2.25f, 2.25f, 1);
            Vector2 movement = moveSpeed * Time.deltaTime * Vector2.left;
            rb.MovePosition(rb.position + movement);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(2.25f, 2.25f, 1);
            Vector2 movement = moveSpeed * Time.deltaTime * Vector2.right;
            rb.MovePosition(rb.position + movement);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector2 movement = moveSpeed * Time.deltaTime * Vector2.up;
            rb.MovePosition(rb.position + movement);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector2 movement = moveSpeed * Time.deltaTime * Vector2.down;
            rb.MovePosition(rb.position + movement);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GrassTile") || other.CompareTag("DirtTile"))
        {
            Destroy(other.gameObject);
            FuelTrackerScript.latestFuel -= 1;
            if (FuelTrackerScript.latestFuel == 0)
            {
                SceneChanger sceneChanger = GetComponent<SceneChanger>();
                sceneChanger.ChangeScene("GameOverScreen");
            }
        }
        if (other.CompareTag("FuelTile"))
        {
            Destroy(other.gameObject);
            FuelTrackerScript.latestFuel += 20;
        }
        else if (other.CompareTag("GoldTile"))
        {
            Destroy(other.gameObject);
            ScoreTrackerScript.latestScore += 100;
        }
        else if (other.CompareTag("PurpleGemTile"))
        {
            Destroy(other.gameObject);
            GemTrackerScript.latestGems += 1;
            SceneChanger sceneChanger = GetComponent<SceneChanger>();
            sceneChanger.ChangeScene("WinScreen");
        }
        else if (other.CompareTag("GreenGemTile"))
        {
            Destroy(other.gameObject);
            GemTrackerScript.latestGems += 1;
        }
        else if (other.CompareTag("BlueGemTile"))
        {
            Destroy(other.gameObject);
            GemTrackerScript.latestGems += 1;
        }
    }
}
