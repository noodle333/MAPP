using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTile : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;

    private Door door;

    private void Start()
    {
        door = GetComponentInChildren<Door>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box" || other.tag == "Player")
        {
            if (particles != null)
            {
                particles.Play();
            }

            else
            {
                Debug.Log("Missing particles");
            }

            door.Open();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Box" || other.tag == "Player") door.Close();
    }
}
