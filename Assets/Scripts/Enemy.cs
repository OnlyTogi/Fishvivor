using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public int EnemyXp = 0;
    public float EnemyHiz = 5f;
    public float hareketMesafesi = 10f;
    private GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("MainFish");
        switch (this.tag)
        {
            case ("1LvlTurtle"):
                EnemyXp = 1000;
                break;
            case ("2LvlTurtle"):
                EnemyXp = 2000;
                break;
            case ("3LvlTurtle"):
                EnemyXp = 3000;
                break;
            case ("4LvlTurtle"):
                EnemyXp = 4000;
                break;
            case ("1LvlSword"):
                EnemyXp = 8000;
                break;
            case ("2LvlSword"):
                EnemyXp = 10000;
                break;
            case ("1LvlJelly"):
                EnemyXp = 10000;
                break;
            case ("2LvlJelly"):
                EnemyXp = 12000;
                break;

        }

    }

    void Update()
    {
        Vector2 hareketYonu = (character.transform.position - transform.position).normalized;
        
        float mesafe = Vector2.Distance(transform.position, character.transform.position);

        if (mesafe <= hareketMesafesi && EnemyXp > character.GetComponent<MainChar>().xp)
        {
            GetComponent<PathFollower>().pathBreakDown = true;
            if (hareketYonu.x >= 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            transform.Translate(hareketYonu*EnemyHiz*Time.deltaTime);
            
        }
        else if(mesafe <= hareketMesafesi && EnemyXp <= character.GetComponent<MainChar>().xp)
        {
            GetComponent<PathFollower>().pathBreakDown = true;
            if (hareketYonu.x >= 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            transform.Translate(hareketYonu * EnemyHiz * Time.deltaTime*-1);


        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}

