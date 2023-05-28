using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_StarGame : MonoBehaviour
{
    public GameObject shadow;
    public Animator transition;
    public AudioSource boxMove;
    public AudioSource switchTrigger;
    public AudioSource buttonClick;
    public Animator startupAnimation;

    public void Awake()
    {
        StartCoroutine(MenuStartup());
    }

    public void StartGame()
    {
        StartCoroutine(LoadLevel());
    }

    public void QuitGame()
    {
        StartCoroutine(Quit());
    }

    public IEnumerator LoadLevel()
    {
        buttonClick.Play();
        transition.Play("Transition out");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }

    public IEnumerator Quit()
    {
        buttonClick.Play();
        transition.Play("Transition out");
        yield return new WaitForSeconds(1);
        Application.Quit();
    }

    public IEnumerator MenuStartup()
    {
        startupAnimation.Play("MenuStartup");
        yield return new WaitForSeconds(1.5f);
        boxMove.Play();
        yield return new WaitForSeconds(1f / 3f);
        boxMove.Play();
        yield return new WaitForSeconds(1f / 6f);
        switchTrigger.Play();
        shadow.SetActive(false);
        yield return new WaitForSeconds(1f / 6f);
        boxMove.Play();

    }
}