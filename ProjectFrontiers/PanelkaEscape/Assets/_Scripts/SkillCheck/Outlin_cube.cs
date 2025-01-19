using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outlin_cube : MonoBehaviour
{
    public GameObject outline;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            outline.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            outline.SetActive(false);
        }
    }
}
