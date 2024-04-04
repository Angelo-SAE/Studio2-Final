using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonitorController : MonoBehaviour
{
    public GameObject blackScreenImage;
    public GameObject whiteScreenImage;

    public GameObject ledObject; // Reference to the LED object

    private bool isBlackScreen = true;

    // Events for when screens are turned on and off
    public event Action ScreenTurnedOn;
    public event Action ScreenTurnedOff;

    void Update()
    {
        // Check for keyboard input to toggle between screens
        if (Input.GetKeyDown(KeyCode.Space)) // Change KeyCode.Space to any desired key
        {
            ToggleScreen();
        }
    }

    // Method to toggle between screens
    public void ToggleScreen()
    {
        isBlackScreen = !isBlackScreen;

        // Enable the appropriate screen image and disable the other one
        blackScreenImage.SetActive(isBlackScreen);
        whiteScreenImage.SetActive(!isBlackScreen);

        // Emit event based on screen state
        if (isBlackScreen)
        {
            ScreenTurnedOff?.Invoke();
        }
        else
        {
            ScreenTurnedOn?.Invoke();
        }

        // Activate or deactivate the LED based on screen state
        if (!isBlackScreen)
        {
            ledObject.SetActive(true); // Activate the LED when screen is turned on
        }
        else
        {
            ledObject.SetActive(false); // Deactivate the LED when screen is turned off
        }
    }
}
