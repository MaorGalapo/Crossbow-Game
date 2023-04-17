using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    // Use this for initialization
    public Text blueScore;
    public Text redScore;
    public Text winText;
    public int red;
    public int blue;

    public int winScore = 10;
    public bool redb;
    public bool blueb;

    public Timer time;

    public inflictDamage player1;
    public inflictDamage player2;
    void Start()
    {
        red = 0;
        blue = 0;
        blueScore.text = "0";
        redScore.text = "0";
        redb = false;
        blueb = false;

    }

    // Update is called once per frame
    void Update()
    {
        redb = red == winScore;
        blueb = blue == winScore;
        if (!(redb || blueb)&& time.timeLeft > 0)
            blue = player1.timesDied;
        if (!(redb || blueb) && time.timeLeft > 0)
            red = player2.timesDied;
        updateText();
    }
    void updateText()
    {
        if (redb || blueb || time.timeLeft <= 0)
        {
            if (redb)
            {
                winText.text = "Red wins";
            }
            if (blueb)
            {
                winText.text = "Blue wins";
            }
            if (time.timeLeft <= 0)
            {
                if (red > blue)
                    winText.text = "Red wins";
                if (blue > red)
                    winText.text = "Blue wins";
                if (blue == red)
                    winText.text = "No One wins";
            }
        }
        else
        {
            blueScore.text = blue.ToString();
            redScore.text = red.ToString();
        }
    }
}
