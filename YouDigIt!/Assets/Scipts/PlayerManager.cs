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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GrassTile"))
        {
            Destroy(collision.gameObject);
        }
    }
}
