using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import the UnityEngine.UI namespace for working with Text components

public class TimeCount : MonoBehaviour
{
    public Text timeText; // Reference to the Text component

    private void Start()
    {
        // Initialize the timeText to display "Time: 0" at the start
        UpdateTimeText(0f);
    }

    private void Update()
    {
        // Get the elapsed time using Time.time
        float elapsedTime = Time.time;

        // Call a function to update the timeText with the elapsed time
        UpdateTimeText(elapsedTime);
    }

    // Function to update the timeText with the elapsed time
    private void UpdateTimeText(float elapsedTime)
    {
        // Format the elapsed time as a string with one decimal place
        string formattedTime = "Time: " + elapsedTime.ToString("F1"); // F1 for one decimal place

        // Update the text element with the formatted time
        timeText.text = formattedTime;
    }
}
