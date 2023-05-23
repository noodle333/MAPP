using UnityEngine;
using System.Collections;

public class SlidingBox : MonoBehaviour
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
            StartCoroutine(SlideBox(moveDirection));

        }
    }

    private IEnumerator SlideBox(Vector3 direction)
    {
        #region particles

        particles.Play();
        var Shape = particles.shape;

        float angle = 0;

        if(direction == Vector3.forward)
        {
            angle = 180;
        }

        else if (direction == Vector3.right)
        {
            angle = 270;
        }

        else if (direction == Vector3.back)
        {
            angle = 0;
        }

        else if (direction == Vector3.left)
        {
            angle = 90;
        }

        Shape.rotation = new Vector3(0, angle, 0);

        #endregion

        transform.position += direction * distanceToMove;
        yield return new WaitForSeconds(0.25f);
        RaycastHit hit;
        if (Physics.BoxCast(transform.position, Vector3.one * 0.4f, direction, out hit, Quaternion.identity, distanceToMove))
        {
            if (hit.transform.tag == "Box" || hit.transform.tag == "Wall")
            {
                Camera.main.GetComponent<ScreenShake>().StartScreenShake(3, 3, 0.2f);
                particles.Stop();

                yield break;
            }
        }
        StartCoroutine(SlideBox(direction));
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
