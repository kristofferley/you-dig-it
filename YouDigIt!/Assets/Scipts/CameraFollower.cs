using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;

    void Update()
    {         
        float verticalSpeed = target.GetComponent<Rigidbody2D>().velocity.y;            
        Vector3 newPosition = transform.position;
        newPosition.y = target.position.y + verticalSpeed * Time.deltaTime;            
        transform.position = newPosition;        
    }
}
