using UnityEngine;
using UnityEngine.SceneManagement;

public class TileManager : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    private Tile[] tiles;

    private void Start()
    {
        tiles = FindObjectsOfType<Tile>();
    }

    private void Update()
    {
        foreach (Tile tile in tiles)
        {
            if (!tile.IsActivated()) return;
        }
        //Win State
        SceneManager.LoadScene(sceneToLoad);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
