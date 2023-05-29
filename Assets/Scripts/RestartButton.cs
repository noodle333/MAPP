using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private TileManager tileManager;
    // Start is called before the first frame update
    public void RestartGame()
    {
        Debug.Log("Hi");
        tileManager.StartCoroutine("RestartGame");
    }

}
