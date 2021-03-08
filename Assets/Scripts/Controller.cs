using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Controller : MonoBehaviour
{
    int redScore;
    int blueScore;
    float countdownTimer;

    public GameObject ball;

    public Text redScoreText;
    public Text blueScoreText;
    public Text countdown;

    public bool counting = true;

    private void Start()
    {
        countdownTimer = 4;
    }
    public void updateScore()
    {
        redScoreText.text = "Score: " + redScore;
        blueScoreText.text = "Score: " + blueScore;
    }

    private void Update()
    {
        if (counting) {
           
            countdownTimer -= Time.deltaTime * 2;
            if(countdownTimer > 1)
            {
           
                countdown.text =  (int)countdownTimer + "";
            }
            else
            {
                ball.GetComponent<BallMovement>().activateBall();
                countdown.text = "";
                counting = false;
            }
        }
    }

    public void resetCountdown()
    {
        counting = true;
        countdownTimer = 4;
    }

    public void incrementBlueScore()
    {
        blueScore++;
        updateScore();
    }
    public void incrementRedScore()
    {
        redScore++;
        updateScore();
    }


    public void exitApplication()
    {
        Application.Quit();
    }
}
