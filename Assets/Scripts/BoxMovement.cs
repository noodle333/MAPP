using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    [SerializeField] private float distanceToMove = 1f;

    public void MoveBox(Vector3 moveDirection)
    {
        transform.position += moveDirection * distanceToMove;
    }
}
