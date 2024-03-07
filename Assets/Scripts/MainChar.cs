using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainChar : MonoBehaviour
{
    public float hiz = 2f;
    public Animator animator;
    public float yatay, dikey;
    public AnimationClip clip;
    public int xp;
    public float scaling = 0f;
    public DynamicJoystick joystick;
    public TextMeshProUGUI skor;
    public float skorCarpan;
    public GameObject manager;
    void Start()
    {
        xp = 100;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        yatay = joystick.Horizontal;
        dikey = joystick.Vertical;
        animator.SetFloat("Horizontal",yatay);
        animator.SetFloat("Vertical",dikey);
        

    }
    private void FixedUpdate()
    {
        Vector3 hareket = new Vector3(yatay, dikey, 0) * hiz * Time.deltaTime;
        transform.Translate(hareket);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            if (xp >= collision.gameObject.GetComponent<Enemy>().EnemyXp)
            {
                StartCoroutine(AttackAnim());
                if (xp >= collision.gameObject.GetComponent<Enemy>().EnemyXp)
                    xp += collision.gameObject.GetComponent<Enemy>().EnemyXp;
                Destroy(collision.gameObject,clip.length*0.5f);
                FishGrow();
            }
            else
            {
                this.gameObject.SetActive(false);
                manager.GetComponent<GameManager>().Kaybettiniz();
            }    
        }
        if (collision.CompareTag("Yosun"))
        {
            StartCoroutine(AttackAnim());
            if (collision.gameObject.GetComponent<Moss>() != null)
                xp += collision.gameObject.GetComponent<Moss>().MossXp;
            FishGrow();
            Destroy(collision.gameObject, clip.length * 0.5f);
            
        }
        if (collision.CompareTag("OctoAttack"))
        {
            this.gameObject.SetActive(false);
            manager.GetComponent<GameManager>().Kaybettiniz();
        }
    }
    IEnumerator AttackAnim()
    {
        animator.SetBool("isAttacking", true);
        yield return new WaitForSeconds(clip.length);
        animator.SetBool("isAttacking", false);
    }

    private void FishGrow()
    {

        scaling = xp / 1500f;
        float newScale = 1.3f + scaling;
        if(newScale >= 6)
        {
            newScale = 6;
        }
        skor.text = Convert.ToString(xp*skorCarpan);
        transform.localScale = new Vector3(newScale,newScale,newScale);
    }
}
