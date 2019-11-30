using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isdead;
    public GameObject PopGameOver;
    public GameObject BTNJump, BTNCrouch,Offpanel;
    public GameObject CameraTexture;
    public PlayerScript player;
    public ScoreManager score;
    public PlayerEmotions playerEmote;
    public PlatformScanner PS;
    public GameObject show;
    private void Awake()
    {
        if (ES2.Exists("controls"))
            player.isbutton = ES2.Load<bool>("controls");
    }
    private void Update()
    {
        GameOver();
        GameStart();
        Controls();
    }
    //popup gameover
    void GameOver()
    {
        if (isdead)
        {
            PopGameOver.SetActive(true);
        }
    }
    public void SceneManage(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    //code for smile first to start the game
    void GameStart()
    {
        float dominantEmotion = Mathf.Max(playerEmote.currentJoy);
        if (!player.isbutton)
        {
            if (playerEmote.currentJoy > 90)
            {
                player.enabled = true;
                score.enabled = true;
                show.SetActive(false);
                PS.enabled = true;

            }
        }
        else
        {
            player.enabled = true;
            score.enabled = true;
            show.SetActive(false);
            CameraTexture.SetActive(false);
            PS.enabled = true;
        }
    }
    public void FaceControl()
    {
        
        player.isbutton = false;
        ES2.Save(player.isbutton, "controls");
        BTNCrouch.SetActive(false);
        BTNJump.SetActive(false);
        Offpanel.SetActive(false);
    }
    public void BTNControl()
    {
        player.isbutton = true;
        ES2.Save(player.isbutton, "controls");
        BTNCrouch.SetActive(true);
        BTNJump.SetActive(true);
        Offpanel.SetActive(false);
    }

    void Controls()
    {
        if (!player.isbutton)
        {
            
            BTNCrouch.SetActive(false);
            BTNJump.SetActive(false);
           
        }
        else
        {
            BTNCrouch.SetActive(true);
            BTNJump.SetActive(true);
        }
    }
}
