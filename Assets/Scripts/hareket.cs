using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareket : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector2 movement;

    void Update()
    {
        // Hareket giriþi al
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // Hareketi uygula
        Vector2 newPosition = (Vector2)transform.position + movement * moveSpeed * Time.fixedDeltaTime;
        transform.position = newPosition;
    }
}
