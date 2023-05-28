using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public GameObject pauseMenu;
    public AudioSource source;
    public static bool isPaused;
    public Button pauseButton;

    void Start()
    {
    pauseMenu.SetActive(false);
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        source.Play();
        Time.timeScale = 0f;
        isPaused = true;
        pauseButton.interactable = false;
    }
}
