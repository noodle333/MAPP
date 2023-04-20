using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float distanceToMove = 1f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) MoveUp();
        if (Input.GetKeyDown(KeyCode.S)) MoveDown();
        if (Input.GetKeyDown(KeyCode.A)) MoveLeft();
        if (Input.GetKeyDown(KeyCode.D)) MoveRight();

    }

    public void MoveUp()
    {
        transform.position += Vector3.forward * distanceToMove;
    }

    public void MoveDown()
    {
        transform.position += Vector3.back * distanceToMove;
    }

    public void MoveLeft()
    {
        transform.position += Vector3.left * distanceToMove;
    }

    public void MoveRight()
    {
        transform.position += Vector3.right * distanceToMove;
    }
}
