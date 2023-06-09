using UnityEngine;
using System.Collections;

public class SlidingBox : MonoBehaviour
{
    [SerializeField] private float distanceToMove = 1f;
    [SerializeField] private LayerMask boxLayerMask;

    private ParticleSystem particles;
    private AudioSource iceBreakSound;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
        iceBreakSound = GetComponent<AudioSource>();
    }

    public void MoveBox(Vector3 moveDirection)
    {
        StartCoroutine(SlideBox(moveDirection));
    }

    private IEnumerator SlideBox(Vector3 direction)
    {
        if (particles != null)
        {
            particles.Play();
        }

        else
        {
            Debug.LogError("Missing particles");
        }

        transform.position += direction * distanceToMove;
        yield return new WaitForSeconds(0.25f);
        RaycastHit hit;

        if (Physics.BoxCast(transform.position, Vector3.one * 0.4f, direction, out hit, Quaternion.identity, distanceToMove))
        {
            if (hit.transform.tag == "Box" || hit.transform.tag == "Wall")
            {
                if (Camera.main.GetComponent<ScreenShake>() != null)
                {
                    Camera.main.GetComponent<ScreenShake>().Shake(1.5f, 0.5f);
                }

                iceBreakSound.Play();

                yield break;
            }
        }
        StartCoroutine(SlideBox(direction));
    }
}
