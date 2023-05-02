using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float distanceToMove = 1f;
    [SerializeField] private LayerMask boxLayerMask;

    private void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.W)) MoveUp();
            if (Input.GetKeyDown(KeyCode.S)) MoveDown();
            if (Input.GetKeyDown(KeyCode.A)) MoveLeft();
            if (Input.GetKeyDown(KeyCode.D)) MoveRight();
        }

    }

    public void MoveUp()
    {
        TryMove(Vector3.forward);
    }

    public void MoveDown()
    {
        TryMove(Vector3.back);
    }

    public void MoveLeft()
    {
        TryMove(Vector3.left);
    }

    public void MoveRight()
    {
        TryMove(Vector3.right);
    }

    private void TryMove(Vector3 direction)
    {
        RaycastHit hit;
        if (Physics.BoxCast(transform.position, Vector3.one * 0.4f, direction, out hit, Quaternion.identity, distanceToMove, boxLayerMask))
        {
            BoxMovement boxMovement = hit.transform.GetComponent<BoxMovement>();
            SlidingBox slidingBox = hit.transform.GetComponent<SlidingBox>();
            if (boxMovement != null) boxMovement.MoveBox(direction);
            else if (slidingBox != null) slidingBox.MoveBox(direction);
        }
        transform.position += direction * distanceToMove;
    }
}
