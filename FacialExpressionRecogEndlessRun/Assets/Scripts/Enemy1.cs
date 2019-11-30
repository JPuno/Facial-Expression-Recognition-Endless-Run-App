﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Transform[] position;
    public Animator animator;

   
    private void Awake()
    {
        RandomEnemy();
        animator = GameObject.FindObjectOfType<Animator>();
    }
    //random the position of enemy
    void RandomEnemy()
    {

        int i = Random.Range(0, 2);
        if (i == 0)
        {
            gameObject.transform.position = position[0].position;
        }
        else
        {
            gameObject.transform.position = position[1].position;
        }
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
