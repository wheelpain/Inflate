using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private Text points;

    [Header("Scoring")]
    [SerializeField]
    private int maxBubbles = 5;
    private int currentPoints = 0;

    public GameObject WinScreen;
    
    
    void Start()
    {
        currentPoints = 0;
        UpdatePointsText();
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Bubble")) return;

        
        // Add one point (clamped to max)
        currentPoints = Mathf.Clamp(currentPoints + 1, 0, maxBubbles);
        UpdatePointsText();

        
    }

    private void UpdatePointsText()
    {
        if (points == null)
        {
            Debug.LogWarning("Points UI Text not assigned on Points component.");
            return;
        }

        points.text = $"{currentPoints}/{maxBubbles} bubbles";
    }

    void Update()
    {
        if (currentPoints >= maxBubbles)
        {
            WinScreen.SetActive(true);
        }
    }
}
