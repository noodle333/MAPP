using UnityEngine;
using System.Collections;

public class SlidingBox : MonoBehaviour
{
    [SerializeField] private float distanceToMove = 1f;

    public void MoveBox(Vector3 moveDirection)
    {
        StartCoroutine(SlideBox(moveDirection));
    }

    private IEnumerator SlideBox(Vector3 direction)
    {
        transform.position += direction * distanceToMove;
        yield return new WaitForSeconds(0.25f);
        RaycastHit hit;
        if (Physics.BoxCast(transform.position, Vector3.one * 0.4f, direction, out hit, Quaternion.identity, distanceToMove))
        {
            if (hit.transform.CompareTag("Box"))
            {
                yield break;
            }
        }
        StartCoroutine(SlideBox(direction));
    }
}
