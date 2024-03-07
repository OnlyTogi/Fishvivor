using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollision : MonoBehaviour
{
    [HideInInspector] public bool isSpawnReach = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Location"))
        {
            isSpawnReach = true;
            Debug.Log("Carpti");
        }
    }
}
