using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;

    private bool opening = false;
    private bool closing = false;

    [SerializeField] private ParticleSystem openingSystem;
    [SerializeField] private ParticleSystem closingSystem;
   
    private void Start()
    {
        startPos = transform.position;
        endPos = startPos + new Vector3(0, -1, 0);
    }

    private void Update()
    {
        if (opening)
        {
            if (transform.position.y <= endPos.y)
            {
                opening = false;
            }

            else
            {
                transform.position -= new Vector3(0, 10f * Time.deltaTime, 0);
            }
        }

        else if (closing)
        {
            if (transform.position.y >= startPos.y)
            {
                closing = false;
            }

            else
            {
                transform.position += new Vector3(0, 0.7f * Time.deltaTime, 0);
            }
        }
    }

    public void Open()
    {
        if (!closing) opening = true;

        openingSystem.Play();
    }

    public void Close()
    {
        if (!opening) closing = true;

        closingSystem.Play();
    }
}
