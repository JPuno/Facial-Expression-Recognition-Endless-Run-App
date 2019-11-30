using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    public AudioSource Source;
    public Image btnimageSource;
    public Sprite mute;
    public Sprite unMute;
    private void Awake()
    {
        SoundManager SM = GameObject.FindObjectOfType<SoundManager>();
        if (ES2.Exists("volume"))
            SM.volume = ES2.Load<int>("volume");
    }
    private void Update()
    {
        Muted();
    }
    // toggle if sound on/off
    public void SoundOn()
    {
        SoundManager SM = GameObject.FindObjectOfType<SoundManager>();
        if (SM.volume == 0)
        {
            SM.volume = 1;
            Source.enabled = false;
            btnimageSource.sprite = mute;
            ES2.Save(SM.volume, "volume");
        }
        else
        {
            SM.volume = 0;
            Source.enabled = true;
            btnimageSource.sprite = unMute;
            ES2.Save(SM.volume, "volume");
        }
    }
    // check if muted or not
    void Muted()
    {
        SoundManager SM = GameObject.FindObjectOfType<SoundManager>();
        if (SM.volume == 1)
        {

            Source.enabled = false;
            btnimageSource.sprite = mute;
        }
        else
        {

            Source.enabled = true;
            btnimageSource.sprite = unMute;
        }
    }
}
