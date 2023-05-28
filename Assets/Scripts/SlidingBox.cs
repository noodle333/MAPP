using UnityEngine;
using System.Collections;

public class SlidingBox : MonoBehaviour
{
    [SerializeField] private float distanceToMove = 1f;
    [SerializeField] private LayerMask boxLayerMask;

    private ParticleSystem particles;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

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
        if (particles != null)
        {
            particles.Play();
        }

        else
        {
            Debug.Log("Missing particles");
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

                else
                {
                    Debug.LogError("Missing screenshake script");
                }

                yield break;
            }
        }
        StartCoroutine(SlideBox(direction));
    }
}
