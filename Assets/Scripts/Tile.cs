using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool isActivated = false;

    public bool IsActivated()
    {
        return isActivated;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box")
        {
            isActivated = true;

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
