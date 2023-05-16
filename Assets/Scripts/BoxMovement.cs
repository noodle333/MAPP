using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    [SerializeField] private float distanceToMove = 1f;

    private ParticleSystem particles;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }


    public void MoveBox(Vector3 moveDirection)
    {
        transform.position += moveDirection * distanceToMove;

        Camera.main.GetComponent<ScreenShake>().StartScreenShake(3, 3, 0.2f);
        particles.Play();
    }
}
