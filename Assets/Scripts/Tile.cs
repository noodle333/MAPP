using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool isActivated = false;

    private ParticleSystem particles;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    public bool IsActivated()
    {
        return isActivated;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box")
        {
            if (particles != null)
            {
                particles.Play();
            }

            else
            {
                Debug.Log("Missing particles");
            }

            isActivated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Box") isActivated = false;
    }
}
