using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TurtleSpawner : MonoBehaviour
{
    public List<Transform> Locations = new List<Transform>();
    public GameObject oneTurtlePrefab; // 1 Lvl Turtle prefab'�
    public GameObject twoTurtlePrefab; // 2 Lvl Turtle prefab'�
    public GameObject threeTurtlePrefab; // 3 Lvl Turtle prefab'�
    public GameObject fourTurtlePrefab; // 4 Lvl Turtle prefab'�
    private GameObject BabyTurtle;
    private int TurtleCountRT; // Sa� �stte bulunan Turtle Say�s�
    private int TurtleCountRB; // Sa� altta bulunan Turtle Say�s�
    private int TurtleCountLT; // Sol �stte bulunan Turtle Say�s�
    private int TurtleCountLB; // Sol altta bulunan Turtle Say�s�
    private int SmallTurtleCount; // K���k Turtle Say�s�
    private int BigTurtleCount; // B�y�k Turtle Say�s�
    private int ToplamTurtle; //Toplam Turtle Say�s�
    private Vector3 TargetPos;
    private bool isTurtleSpawned;
    private SpawnCollision spawnCollision;

    public float moveSpeed = 0.1f; // Turtle'�n hareket h�z�

    void Update()
    {
        // Turtle say�s�n� kontrol et
        if (ToplamTurtle < 5 && !isTurtleSpawned)
        {
            isTurtleSpawned = true;
            CAS();

        }
        if(isTurtleSpawned)
        {
            Vector2 targetDirection = (TargetPos-BabyTurtle.transform.position).normalized;
            MoveTurtleTowardsTarget(BabyTurtle, targetDirection);
            if (spawnCollision.isSpawnReach)
            {
                BabyTurtle.GetComponent<Rigidbody2D>().isKinematic = true;
                BabyTurtle.GetComponent<Rigidbody2D>().isKinematic = false;
                BabyTurtle.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                isTurtleSpawned = false;
            }
        }
    }

    void SpawnTurtles()
    {
        int secim1;
        
        while (SmallTurtleCount <= 2)
        {
            secim1 = Random.Range(1, 3);
            if (secim1 == 1)
            {
                // Turtle spawn etme i�lemi
                GameObject newTurtle = Instantiate(oneTurtlePrefab, GetSpawnPositionAboveScreen(), Quaternion.identity);
                Debug.Log(newTurtle.transform.position);
                BabyTurtle = newTurtle;
                spawnCollision = newTurtle.GetComponent<SpawnCollision>();
                SmallTurtleCount++;
                ToplamTurtle++;
                return;
            }
            else if (secim1 == 2)
            {
                // Turtle spawn etme i�lemi
                GameObject newTurtle = Instantiate(twoTurtlePrefab, GetSpawnPositionAboveScreen(), Quaternion.identity);
                Debug.Log(newTurtle.transform.position);
                BabyTurtle = newTurtle;
                spawnCollision = newTurtle.GetComponent<SpawnCollision>();
                SmallTurtleCount++;
                ToplamTurtle++;
                return;
            }
        }
        while(BigTurtleCount <= 2)
        {
            secim1 = Random.Range(1, 3);
            if (secim1 == 1)
            {
                // Turtle spawn etme i�lemi
                GameObject newTurtle = Instantiate(threeTurtlePrefab, GetSpawnPositionAboveScreen(), Quaternion.identity);
                Debug.Log(newTurtle.transform.position);
                BabyTurtle = newTurtle;
                spawnCollision = newTurtle.GetComponent<SpawnCollision>();
                BigTurtleCount++;
                ToplamTurtle++;
                return;
            }
            else if (secim1 == 2)
            {
                // Turtle spawn etme i�lemi
                GameObject newTurtle = Instantiate(fourTurtlePrefab, GetSpawnPositionAboveScreen(), Quaternion.identity);
                Debug.Log(newTurtle.transform.position);
                BabyTurtle = newTurtle;
                spawnCollision = newTurtle.GetComponent<SpawnCollision>();
                BigTurtleCount++;
                ToplamTurtle++;
                return;
            }
        }
            
        
    }

    Vector3 GetSpawnPositionAboveScreen()
    {
        // Ekran�n �st�nden biraz daha y�ksekte spawn etmek i�in kullan�lacak pozisyon
        float randomX = Random.Range(-10f, 10f); // X koordinat� s�n�rlar�
        float aboveScreenY = Camera.main.orthographicSize + 2f; // Ekran�n �st�nde biraz daha y�ksekte spawn et
        return new Vector3(randomX, aboveScreenY, 0f);
    }

    void MoveTurtleTowardsTarget(GameObject turtle, Vector2 targetPosition)
    {
        // Turtle'� yava��a hedef konuma hareket ettir
        //turtle.transform.position = Vector3.MoveTowards(turtle.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        //Vector3.Lerp(turtle.transform.position , targetPosition , moveSpeed * Time.deltaTime);
        turtle.GetComponent<Rigidbody2D>().AddForce(targetPosition);
    }

    void CAS()
    {
        int secim2;
        secim2 = Random.Range(1, 5);
        switch (secim2)
        {
            case 1:
                {
                    if (TurtleCountRT == 1) 
                    {
                        //CAS();
                        return;
                    }
                    else
                    {
                        SpawnTurtles();
                        TargetPos = Locations[0].position;
                        Debug.Log("RT: "+BabyTurtle.name);
                        TurtleCountRT++;
                        isTurtleSpawned = true;
                    }
                    break;
                }
            case 2:
                {
                    if (TurtleCountRB == 1)
                    {
                        //CAS();
                        return;
                    }
                    else
                    {
                        SpawnTurtles();
                        TargetPos = Locations[1].position;
                        Debug.Log("RB: " + BabyTurtle.name);
                        TurtleCountRB++;
                        isTurtleSpawned = true;
                    }
                    break;
                }
            case 3:
                {
                    if (TurtleCountLT == 1)
                    {
                        //CAS();
                        return;
                    }
                    else
                    {
                        SpawnTurtles();
                        TargetPos = Locations[2].position;
                        Debug.Log("LT: " + BabyTurtle.name);
                        TurtleCountLT++;
                        isTurtleSpawned = true;
                    }
                    break;
                }
            case 4:
                {
                    if (TurtleCountLB == 1)
                    {
                        //CAS();
                        return;
                    }
                    else
                    {
                        SpawnTurtles();
                        TargetPos = Locations[3].position;
                        Debug.Log("LB: " + BabyTurtle.name);
                        TurtleCountLB++;
                        isTurtleSpawned = true;
                    }
                    break;
                }
        }
    }
}

