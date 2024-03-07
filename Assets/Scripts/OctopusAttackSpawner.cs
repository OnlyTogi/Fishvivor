using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusAttackSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float olusturmaSuresi = 2f; 
    private float gecenSure = 0f;
    public float alcaklik;

    void Update()
    {
        gecenSure += Time.deltaTime;

        if (gecenSure >= olusturmaSuresi)
        {
            NesneOlustur(); 
            gecenSure = 0f; 
        }
    }

    void NesneOlustur()
    {
        
        GameObject yeniNesne = Instantiate(prefab, transform.position, Quaternion.identity);
        yeniNesne.GetComponent<OctoAttackDestroyer>().yokolusAlcakligi = alcaklik;


    }
}
