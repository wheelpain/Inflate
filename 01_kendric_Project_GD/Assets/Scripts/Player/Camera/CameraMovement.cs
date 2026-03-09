using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;//player
    public float distance = 5f;
    public float sensitivity = 5f;


    float yaw = 0f; //left right rotation
    float pitch = 20f; // up-down rotation

    private void LateUpdate()
    {
        // Mouse input
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;

        // Clamp vertical rotation (prevents flipping)
        pitch = Mathf.Clamp(pitch, -30f, 70f);

        // Rotation around player
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        // Position camera behind player
        Vector3 position = target.position - rotation * Vector3.forward * distance;

        transform.position = position;

        // Always look at the player
        transform.LookAt(target);
    }
}
