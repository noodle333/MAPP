using UnityEngine;
using UnityEngine.SceneManagement;

public class TileManager : MonoBehaviour
{
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
