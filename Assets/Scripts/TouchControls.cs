using UnityEngine;

public class TouchControls : MonoBehaviour
{
    [SerializeField] private float distanceToMove = 1f;
    [SerializeField] private LayerMask boxLayerMask;

    [SerializeField] private Vector2 swipeStartPos;
    [SerializeField] private Vector2 swipeEndPos;
    [SerializeField] private Vector2 currentSwipe;

    private bool canMove = true;
    private string swipeDirection;

    private void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.W)) MoveUp();
            if (Input.GetKeyDown(KeyCode.S)) MoveDown();
            if (Input.GetKeyDown(KeyCode.A)) MoveLeft();
            if (Input.GetKeyDown(KeyCode.D)) MoveRight();
        }

        DetectSwipeInput();
        if (Input.touches.Length > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended && canMove)
            {
                print("swiped");
                canMove = false;
                if (swipeDirection == "Up")
                {
                    MoveUp();
                }
                else if (swipeDirection == "Down")
                {
                    MoveDown();
                }
                else if (swipeDirection == "Left")
                {
                    MoveLeft();
                }
                else if (swipeDirection == "Right")
                {
                    MoveRight();
                }
            }
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
        print("moved");
        swipeDirection = "None";
        RaycastHit hit;
        if (Physics.BoxCast(transform.position, Vector3.one * 0.4f, direction, out hit, Quaternion.identity, distanceToMove, boxLayerMask))
        {
            BoxMovement boxMovement = hit.transform.GetComponent<BoxMovement>();
            SlidingBox slidingBox = hit.transform.GetComponent<SlidingBox>();
            if (boxMovement != null) boxMovement.MoveBox(direction);
            else if (slidingBox != null) slidingBox.MoveBox(direction);
        }
        transform.position += direction * distanceToMove;
        canMove = true;
    }

    private void DetectSwipeInput()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                swipeStartPos = new Vector2(t.position.x, t.position.y);
            }

            if (t.phase == TouchPhase.Ended)
            {
                swipeEndPos = new Vector2(t.position.x, t.position.y);
                currentSwipe = new Vector3(swipeEndPos.x - swipeStartPos.x, swipeEndPos.y - swipeStartPos.y);

                if (currentSwipe.magnitude < 40)
                {
                    return;
                }
            }

            currentSwipe.Normalize();

            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                swipeDirection = "Up";
            }
            else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                swipeDirection = "Down";
            }
            else if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                swipeDirection = "Left";
            }
            else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                swipeDirection = "Right";
            }
            else
            {
                swipeDirection = "None";
            }
        }
    }
}
