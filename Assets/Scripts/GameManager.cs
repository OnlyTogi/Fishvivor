using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int hedefXPSayisi; 
    public GameObject kazandinizPanel;
    public GameObject kaybettinizPanel;
    public Button sonrakiSahneButton;
    public Button tekrarDene;
    public GameObject karakter;
    private bool oyunDurdu = false;

    void Start()
    {
        kazandinizPanel.SetActive(false);
        kaybettinizPanel.SetActive(false);
        sonrakiSahneButton.onClick.AddListener(SonrakiSahneyeGec);
        tekrarDene.onClick.AddListener(yenidenBaslat);
    }

    void Update()
    {
        if (!oyunDurdu)
        {
            if (karakter.GetComponent<MainChar>().xp >= hedefXPSayisi)
            {
                OyunuDurdur();
            }
            
        }
    }

    void OyunuDurdur()
    {
        oyunDurdu = true; 

        
        kazandinizPanel.SetActive(true);
        Time.timeScale = 0f;

    }
    public void Kaybettiniz()
    {
            oyunDurdu = true;
            kaybettinizPanel.SetActive(true);
            Time.timeScale = 0f;
    }

    void SonrakiSahneyeGec()
    {
        if (SceneManager.GetActiveScene().name == "level3")
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1f;
        }
    }
    void yenidenBaslat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
