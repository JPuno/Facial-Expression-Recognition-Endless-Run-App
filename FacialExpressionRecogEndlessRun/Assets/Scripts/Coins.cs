using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public AudioSource AS;
    public AudioClip AC;
    private void Awake()
    {
        AS = FindObjectOfType<AudioSource>();
    }
    //trigger to collect coins
    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            Coinss();
           
        }
       
    }
    
    //code for coins function
    void Coinss()
    {
        AS.PlayOneShot(AC);
        ScoreManager SM = FindObjectOfType<ScoreManager>();
        SM.scoreCount += 10;
        SM.coin += 1;
        Destroy(gameObject);
    }
}
