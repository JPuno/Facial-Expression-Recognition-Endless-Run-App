using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public Text GAmeOverScore;
    public Text CoinsEarnings;
    public bool isdead;
    public int scoreCount;
    public int highScoreCount;
    public int pointsPerSecond;
    private float time=1;
    public bool scoreIncreasing;
    public int coin;

    private void Awake()
    {
        // loading if highscore data is exist
        if (ES2.Exists("HScore"))
            highScoreCount = ES2.Load<int>("HScore");
    }
    void Update()
    {
        Score();
        CoinsEarned();
    }
    //displaying score, saving high score and added score per second
    void Score()
    {
        if (!isdead)
        {
            if (time <= 0)
            {

                scoreCount += pointsPerSecond;
                time = 1;
            }
            time -= Time.deltaTime;
            time = Mathf.Clamp(time, 0f, Mathf.Infinity);

        }

        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            ES2.Save(highScoreCount, "HScore"); //saving your score
        }

        scoreText.text = "Score: " + scoreCount;
        highScoreText.text = "High Score: " + highScoreCount;
        GAmeOverScore.text= scoreCount.ToString();
    }
    //displaying earned coins
    void CoinsEarned()
    {
        CoinsEarnings.text = "Coins:" + coin;
    }
}
