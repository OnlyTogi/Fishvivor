using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OctoAttackDestroyer : MonoBehaviour
{
    public float yokolusAlcakligi;

    private void Update()
    {
        if (transform.position.y <= yokolusAlcakligi)
        {
            Destroy(this.gameObject);
        }
    }
}
