using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    private bool isPaused = false;
    public GameObject PauseMenu;
    public AudioSource Audio;
    void Update()
    {
        if (isPaused == true)
        {
            Paused();
        }
        else
        {
            Resume();
        }
    }

    public void Paused()
    {



        Audio.Pause();
        isPaused = true;
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {

        Audio.UnPause();
        isPaused = false;
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
    }
}
