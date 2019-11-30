using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScanner : MonoBehaviour
{
    public int scanCoin;
    public int scanpowerups;
    public int performanceinCoin;
    public int performanceinPowerups;
    public int collectedcoins;
    public int collectedPowerups;
    public float _speed;
    public CharacterController _controller;
    public bool isdead;
    private void Update()
    {
        PerformanceFormula();
        move();
    }
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.CompareTag("coins"))
        {
            scanCoin += 1;

        }

        if (collision.CompareTag("powerups"))
        {
            scanpowerups += 1;

        }
    }
    void PerformanceFormula()
    {
        PlayerScript PS = FindObjectOfType<PlayerScript>();
        ScoreManager SM = FindObjectOfType<ScoreManager>();
        PlatformGenerator1 PF = FindObjectOfType<PlatformGenerator1>();
        collectedcoins = SM.coin;
        if (PS.time<=0)
        {
            if(scanCoin!=0&&collectedcoins!=0)
            performanceinCoin = ((scanCoin) / (collectedcoins))*10;
            if(scanpowerups!=0&&collectedPowerups!=0)
            performanceinPowerups = ((scanpowerups) / (collectedPowerups))*10;
            if (performanceinCoin >= 64 && performanceinPowerups>=64)
            {
                PS._speed += 1f;
               PF.theObjectPools[7] = PF.ChangeObject[2];
                PF.theObjectPools[8] = PF.ChangeObject[2];
            }
            else if(performanceinCoin <= 34 && performanceinPowerups <= 34)
            {
                PS._speed -= .1f;
                PF.theObjectPools[7] = PF.ChangeObject[0];
                PF.theObjectPools[8] = PF.ChangeObject[0];
            }
            scanCoin = 0;
            scanpowerups = 0;
            collectedcoins = 0;
            collectedPowerups = 0;
        }
    }
    void move()
    {
        if (!isdead)
        {
            Vector3 direction = new Vector3(1, 0, 0);
            Vector3 velocity = direction * _speed;
            _controller.Move(velocity * Time.deltaTime);
        }
    }

}
