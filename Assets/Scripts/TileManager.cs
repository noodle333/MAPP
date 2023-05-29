using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileManager : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    private Tile[] tiles;
    [SerializeField] private Animator transition;

    private void Awake()
    {
        transition = GameObject.Find("Transition").GetComponent<Animator>();
        tiles = FindObjectsOfType<Tile>();
        transition.Play("Transition in");
    }

    private void Update()
    {
        foreach (Tile tile in tiles)
        {
            if (!tile.IsActivated()) return;
        }
        //Win State
        StartCoroutine(nextLevel());
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator nextLevel()
    {
        transition.Play("Transition out");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneToLoad);
    }

    public IEnumerator RestartGame()
    {
        Debug.Log("Hi");
        transition.Play("Transition out");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
