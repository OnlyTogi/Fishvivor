using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioSource music;
    public void baslaButon()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void kapatButon()
    {
        Application.Quit();
    }
    public void sesAc()
    {
        music.volume = 0.1f;
    }
    public void sesKapa()
    {
        music.volume = 0f;
    }
    public void linkac()
    {
        Application.OpenURL("https://youtube.com/shorts/HrxEm4RcWvs?si=Cl7RBKJFKxKmw8mR");
    }
}
