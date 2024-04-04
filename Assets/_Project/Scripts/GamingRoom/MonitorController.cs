using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorController : MonoBehaviour
{
    public GameObject blackScreenImage;
    public GameObject whiteScreenImage;

    private bool isBlackScreen = true;

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
    }
}
