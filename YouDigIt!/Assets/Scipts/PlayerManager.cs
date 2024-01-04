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
        FuelTrackerScript.latestFuel = 30;
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
        if (ScoreTrackerScript.latestScore == 4000)
        {
            SceneChanger sceneChanger = GetComponent<SceneChanger>();
            sceneChanger.ChangeScene("WinScreen");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("UnpassableBaseTile")) 
        {
            Collider2D diggerCollider = GetComponent<Collider2D>();
            float yDifference = Mathf.Abs(diggerCollider.bounds.center.y - other.bounds.center.y);
            float xDifference = Mathf.Abs(diggerCollider.bounds.center.x - other.bounds.center.x);
            if (xDifference < 0.4f || yDifference < 0.45f)
            {
                Destroy(other.gameObject);
            } 
        }
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
            FuelTrackerScript.latestFuel += 8;
        }
        else if (other.CompareTag("GoldTile"))
        {
            Destroy(other.gameObject);
            ScoreTrackerScript.latestScore += 200;
        }
        else if (other.CompareTag("PurpleGemTile"))
        {
            Destroy(other.gameObject);
            GemTrackerScript.latestGems += 1;
            ScoreTrackerScript.latestScore -= 500;
            if (GemTrackerScript.latestGems == 3)
            {
                ScoreTrackerScript.latestScore += 2500;
            }
        }
        else if (other.CompareTag("GreenGemTile"))
        {
            Destroy(other.gameObject);
            GemTrackerScript.latestGems += 1;
            ScoreTrackerScript.latestScore -= 500;
            if (GemTrackerScript.latestGems == 3)
            {
                ScoreTrackerScript.latestScore += 2500;
            }
        }
        else if (other.CompareTag("BlueGemTile"))
        {
            Destroy(other.gameObject);
            GemTrackerScript.latestGems += 1;
            ScoreTrackerScript.latestScore -= 500;
            if (GemTrackerScript.latestGems == 3)
            {
                ScoreTrackerScript.latestScore += 2500;
            }
        }
    }
}
