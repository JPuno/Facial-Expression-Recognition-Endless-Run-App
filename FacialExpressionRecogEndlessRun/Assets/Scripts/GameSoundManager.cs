using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundManager : MonoBehaviour
{
    public AudioSource Source;
    void Update()
    {
       Muted();
    }
    // check if muted or not    
   void Muted()
   {
       SoundManager SM = GameObject.FindObjectOfType<SoundManager>();
       if (SM.volume == 1)
       {
  
           Source.enabled = false;
           
       }
       else
       {
  
           Source.enabled = true;
           
       }
   }
}
