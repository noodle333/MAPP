using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float distanceToMove = 1f;
    [SerializeField] private LayerMask boxLayerMask;

    private void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.W)) TryMove(Vector3.forward);
            if (Input.GetKeyDown(KeyCode.S)) TryMove(Vector3.back);
            if (Input.GetKeyDown(KeyCode.A)) TryMove(Vector3.left);
            if (Input.GetKeyDown(KeyCode.D)) TryMove(Vector3.right);
        }

    }

    private void TryMove(Vector3 direction)
    {
        RaycastHit hit;
        if (Physics.BoxCast(transform.position, Vector3.one * 0.4f, direction, out hit, Quaternion.identity, distanceToMove, boxLayerMask))
        {
            if (hit.transform.tag == "Wall") return;

            BoxMovement boxMovement = hit.transform.GetComponent<BoxMovement>();
            SlidingBox slidingBox = hit.transform.GetComponent<SlidingBox>();
            if (boxMovement != null) boxMovement.MoveBox(direction);
            else if (slidingBox != null) slidingBox.MoveBox(direction);
        }
        transform.position += direction * distanceToMove;
    }
}
