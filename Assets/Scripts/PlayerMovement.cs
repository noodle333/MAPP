using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float distanceToMove = 1f;
    [SerializeField] private LayerMask boxLayerMask;
    private AudioSource sound;

    [SerializeField] private Vector2 swipeStartPos, swipeEndPos, currentSwipe;
    [SerializeField] private string swipeDirection;
    [SerializeField] private bool canMove = true;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (!PauseMenu.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.W)) TryMove(Vector3.forward);
            if (Input.GetKeyDown(KeyCode.S)) TryMove(Vector3.back);
            if (Input.GetKeyDown(KeyCode.A)) TryMove(Vector3.left);
            if (Input.GetKeyDown(KeyCode.D)) TryMove(Vector3.right);
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
        canMove = true;
        RaycastHit hit;
        if (sound != null) sound.Play();
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
