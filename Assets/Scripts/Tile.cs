using UnityEngine;

public class Tile : MonoBehaviour
{
    private AudioSource sound;
    private bool isActivated = false;
    private ParticleSystem particles;


    private void Start()
    {
        sound = GetComponent<AudioSource>();
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
            if (particles != null) particles.Play();

            sound.pitch = 1f;
            sound.Play();
            isActivated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Box")
        {
            sound.pitch = 0.5f;
            sound.Play();
            isActivated = false;
        }
    }
}
