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
            isActivated = true;

            particles.Play();

            other.SendMessage("UpdateState");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Box")
        {
            isActivated = false;

            other.SendMessage("UpdateState");
        }
    }
}
