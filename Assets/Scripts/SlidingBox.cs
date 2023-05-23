using UnityEngine;
using System.Collections;

public class SlidingBox : MonoBehaviour
{
    [SerializeField] private float distanceToMove = 1f;
    [SerializeField] private LayerMask boxLayerMask;

    public void MoveBox(Vector3 moveDirection)
    {
        RaycastHit hit;
        if (!Physics.BoxCast(transform.position, Vector3.one * 0.4f, moveDirection, out hit, Quaternion.identity, distanceToMove, boxLayerMask))
        {
            StartCoroutine(SlideBox(moveDirection));

        }
    }

    private IEnumerator SlideBox(Vector3 direction)
    {
        transform.position += direction * distanceToMove;
        yield return new WaitForSeconds(0.25f);
        RaycastHit hit;
        if (Physics.BoxCast(transform.position, Vector3.one * 0.4f, direction, out hit, Quaternion.identity, distanceToMove))
        {
            if (hit.transform.tag == "Box" || hit.transform.tag == "Wall")
            {
                yield break;
            }
        }
        StartCoroutine(SlideBox(direction));
    }
}
