using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
   
    public Animator animator;
    public AudioSource AS;
    public AudioClip AC;
    private void Awake()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        AS = FindObjectOfType<AudioSource>();
    }
    //trigger to die player
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Die();
        }
    }
    //disable a function when die
    void Die()
    {
        AS.PlayOneShot(AC);
        PlayerScript player = GameObject.FindObjectOfType<PlayerScript>();
        ScoreManager s = GameObject.FindObjectOfType<ScoreManager>();
        PlatformGenerator1 plat = FindObjectOfType<PlatformGenerator1>();
        GameManager GM = FindObjectOfType<GameManager>();
        plat.enabled = false;
        player.isdead = true;
        s.isdead = true;
        GM.isdead = true;
        player._speed = 0;
        animator.SetBool("IsCrouching", false);
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsDead", true);
        

    }
}
