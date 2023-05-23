using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_StarGame : MonoBehaviour
{
    public GameObject shadow;
    public Animator transition;

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
        transition.Play("Transition out");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }

    public IEnumerator Quit()
    {
        transition.Play("Transition out");
        yield return new WaitForSeconds(1);
        Application.Quit();
    }

    public IEnumerator MenuStartup()
    {
        print("bada bing");
        yield return new WaitForSeconds(2);
        shadow.SetActive(false);
        print("bada boom");
    }
}