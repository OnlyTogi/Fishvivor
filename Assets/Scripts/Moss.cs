using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moss : MonoBehaviour
{
    public int MossXp = 100;
    public float hareketHizi = 5.0f;
    public float yukariHareketMiktari = 1.0f;
    public float yukseklik;

    // Update is called once per frame
    void Update()
    {
        Vector3 yukariHareket = Vector3.up * yukariHareketMiktari;
        transform.Translate(yukariHareket * hareketHizi * Time.deltaTime);
        if(transform.position.y >= yukseklik)
        {
            Destroy(this.gameObject);
        }
    }
    
}
