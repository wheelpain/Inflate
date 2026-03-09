using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 60f;       // Start with 60 seconds
    public Text timerText;                  // Reference to UI Text
    public GameObject losePanel;            // Reference to Lose Panel

    private bool timerRunning = true;

    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerRunning = false;
                losePanel.SetActive(true);  // Show lose panel
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        // Round up to nearest whole number
        int seconds = Mathf.CeilToInt(timeToDisplay);
        timerText.text = seconds.ToString();
    }
}