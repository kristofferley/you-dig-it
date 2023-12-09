using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public LayerMask destructibleLayer;

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Move(input);
    }

    void Move(Vector2 direction)
    {
        Vector2 currentPosition = transform.position;
        Vector2 targetPosition = currentPosition + moveSpeed * direction * Time.fixedDeltaTime;
        targetPosition = RoundToNearestGridPoint(targetPosition);
        RaycastHit2D[] hits = Physics2D.RaycastAll(currentPosition, direction, moveSpeed * Time.fixedDeltaTime, destructibleLayer);
        foreach (RaycastHit2D hit in hits)
        {
            if (!IsIndestructibleTile(hit.collider.gameObject))
            {
                hit.collider.gameObject.SetActive(false);
            }
        }
        transform.position = targetPosition;
    }

    Vector2 RoundToNearestGridPoint(Vector2 position)
    {
        return new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));
    }


    bool IsIndestructibleTile(GameObject obj)
    {
        return obj.CompareTag("IndestructibleTile");
    }
}