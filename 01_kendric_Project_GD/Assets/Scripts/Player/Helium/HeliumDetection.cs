using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliumDetection : MonoBehaviour
{
    bool isNearCanister = false;
    public HeliumBar heliumBar;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered by: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            heliumBar.SetNearCanister(true);
            Debug.Log("Collided with: " + other.name);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            heliumBar.SetNearCanister(false);
            Debug.Log("Collided with: " + other.name);
        }
        else
            return;
    }
}
