using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Transform[] position;
    public GameObject power;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public SpriteRenderer PowerUp;
    public AudioSource AS;
    public AudioClip AC;
    private void Awake()
    {
        RandomFood();
        AS = FindObjectOfType<AudioSource>();
    }

    //randomize the position and sprite
    void RandomFood()
    {
        int i = Random.Range(0, 2);
        int a = Random.Range(0, 7);
        if (a == 0)
        {
            PowerUp.sprite = sprite1;
        }
        else if (a == 1)
        {
            PowerUp.sprite = sprite2;
        }
        else if (a == 2)
        {
            PowerUp.sprite = sprite3;
        }
        else if (a == 3)
        {
            PowerUp.sprite = sprite4;
        }
        else if (a == 4)
        {
            PowerUp.sprite = sprite5;
        }

        if (i == 0 || i ==1)
        {
            gameObject.transform.position = position[0].position;
            
        }
        else if(i==5 || i==3)
        {
            gameObject.transform.position = position[1].position;
        }
        else
        {
            power.SetActive(false);
        }
    }
    //trigger to collect food
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            FoodUps();
            Destroy(gameObject);
        }
    }

    //food function
    void FoodUps()
    {
        AS.PlayOneShot(AC);
        PlayerScript PS = FindObjectOfType<PlayerScript>();
        PlatformScanner PFS = FindObjectOfType<PlatformScanner>();
        PS.stamina += 50;
        PFS.collectedPowerups += 1;
        if (PS.stamina >= 100)
        {
            PS.stamina = 100;
        }
    }

}
