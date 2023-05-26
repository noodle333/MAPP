using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    [SerializeField] private float distanceToMove = 1f;
    [SerializeField] private LayerMask boxLayerMask;

    public void MoveBox(Vector3 moveDirection)
    {
        RaycastHit hit;
        if (!Physics.BoxCast(transform.position, Vector3.one * 0.4f, moveDirection, out hit, Quaternion.identity, distanceToMove, boxLayerMask))
        {
            transform.position += moveDirection * distanceToMove;

            if(Camera.main.GetComponent<ScreenShake>() != null)
            {
                Camera.main.GetComponent<ScreenShake>().Shake(3f, 0.2f);
            }

            else
            {
                Debug.LogError("Missing screenshake script");
            }
        }
    }
}
