using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MossSpawner : MonoBehaviour
{
    public Moss mossPrefab;
    public List<Moss> spawnedMossList = new List<Moss>();
    public int maxSpawnCount = 15;
    public float spawnPeriod = 1f;
    private float nextSpawnTime = 0f;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float yokolusyukseklik;
    public float harekethizi;

    private void Update()
    {
        HandleNullElements();
        if (spawnedMossList.Count >= maxSpawnCount)
            return;
        if(Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time +spawnPeriod;
            spawnObject();
        }
    }

    private void spawnObject()
    {
        float spawnX = Random.Range(minX, maxX);
        float spawnY = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);
        var moss = Instantiate(mossPrefab, null);
        moss.transform.position = spawnPos;
        moss.GetComponent<Moss>().yukseklik = yokolusyukseklik;
        moss.GetComponent<Moss>().hareketHizi = harekethizi;
        spawnedMossList.Add(moss);


    }

    private void HandleNullElements()
    {
        for (int i = spawnedMossList.Count - 1; i >= 0; i--)
        {
            if (spawnedMossList[i] == null)
            {
                spawnedMossList.RemoveAt(i);
            }
        }

    }


    
}
