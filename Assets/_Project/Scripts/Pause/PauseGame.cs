using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private Publisher publisher;
    [SerializeField] private Mode mode;
    [SerializeField] private GameObject pauseMenu, optionsMenu;
    private bool isActive;

    private void Update()
    {
      Pause();
    }

    private void Pause()
    {
      if(Input.GetButtonDown("Pause"))
      {
        if (optionsMenu.activeSelf)
        {
          return;
        }
        if(mode.mode3D)
        {
          PauseTheGame();
        } else if(!mode.mode3D && isActive)
        {
          ResumeTheGame();
        }
      }
    }

    private void PauseTheGame()
    {
      mode.mode3D = false;
      isActive = true;
      pauseMenu.SetActive(true);
      Time.timeScale = 0f;
      publisher.NotifySubscribers();
    }

    public void ResumeTheGame()
    {
      mode.mode3D = true;
      isActive = false;
      pauseMenu.SetActive(false);
      Time.timeScale = 1f;
      publisher.NotifySubscribers();
    }

    public void OpenOptionsMenu()
    {
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void CloseOptionsMenu()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
