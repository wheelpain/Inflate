using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliTransform : MonoBehaviour

{
    public GameObject humanModel;
    public GameObject ballModel;
    public Rigidbody rb;
    public float floatStrength = 15f;

    public bool isBall;
    public bool isHuman = true;


    public static HeliTransform instance;

    private void Start()
    {
        instance = this;
    }
    void Update()
    {
        
    }

    public void TransformToBall()
    {
        humanModel.SetActive(false);
        ballModel.SetActive(true);
        rb.drag = 2f;          // Add air resistance
        rb.mass = 5;
        isBall = true;
        isHuman = false;
    }

    public void TransformToHuman()
    {
        humanModel.SetActive(true);
        ballModel.SetActive(false);
        rb.drag = 0f;
        isBall = false;
        isHuman = true;
        rb.mass = 10;

    }

    void FixedUpdate()
    {
        if (ballModel.activeSelf)
        {
            rb.AddForce(Vector3.up * floatStrength); // Constant upward float
        }
    }
}
