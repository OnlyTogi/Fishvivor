using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float hiz = 5f;
    public GameObject karakterx;
    public GameObject karaktery;

    void Update()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        float yeniPozisyonX = karakterx.transform.position.x;
        float yeniPozisyonY = karaktery.transform.position.y;
        yeniPozisyonX = Mathf.Clamp(yeniPozisyonX, minX, maxX);
        yeniPozisyonY = Mathf.Clamp(yeniPozisyonY, minY, maxY);
        transform.position = new Vector3(yeniPozisyonX, yeniPozisyonY, transform.position.z);
    }
}
