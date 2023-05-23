using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    [SerializeField] private float distanceToMove = 1f;
    [SerializeField] private LayerMask boxLayerMask;

    private ParticleSystem particles;

    private bool isActiveState = true;

    [SerializeField] private Material activeStateMaterial;
    [SerializeField] private Material inactiveStateMaterial;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }


    public void MoveBox(Vector3 moveDirection)
    {
        RaycastHit hit;
        if (!Physics.BoxCast(transform.position, Vector3.one * 0.4f, moveDirection, out hit, Quaternion.identity, distanceToMove, boxLayerMask))
        {
            transform.position += moveDirection * distanceToMove;
        }

        Camera.main.GetComponent<ScreenShake>().StartScreenShake(3, 3, 0.2f);
        particles.Play();
    }

    public void UpdateState()
    {
        isActiveState = !isActiveState;

        if (isActiveState == false)
        {
            SetInactive();
        }

        else
        {
            SetActive();
        }
    }

    public void SetActive()
    {
        GetComponent<MeshRenderer>().material = activeStateMaterial;
    }

    public void SetInactive()
    {
        GetComponent<MeshRenderer>().material = inactiveStateMaterial;
    }
}
