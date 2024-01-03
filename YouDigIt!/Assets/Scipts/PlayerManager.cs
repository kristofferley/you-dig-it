using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;

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
        }
        if (other.CompareTag("FuelTile"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("GoldTile"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("PurpleGemTile"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("GreenGemTile"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("BlueGemTile"))
        {
            Destroy(other.gameObject);
        }
    }
}
