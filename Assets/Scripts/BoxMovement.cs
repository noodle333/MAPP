using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    [SerializeField] private float distanceToMove = 1f;
    [SerializeField] private LayerMask boxLayerMask;

    private ParticleSystem particles;
    private AudioSource boxSlideSound;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
        boxSlideSound = GetComponent<AudioSource>();
    }

    public void MoveBox(Vector3 moveDirection)
    {
        transform.position += moveDirection * distanceToMove;

        if (particles != null)
        {
            particles.Play();
        }

        
        if (particles != null)
        {
                particles.Play();
        }

        if (Camera.main.GetComponent<ScreenShake>() != null)
        {
                Camera.main.GetComponent<ScreenShake>().Shake(3f, 0.2f);
        }

        boxSlideSound.Play();
    }
}
