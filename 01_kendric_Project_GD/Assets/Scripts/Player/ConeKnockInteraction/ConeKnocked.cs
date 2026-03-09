using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeKnocked : MonoBehaviour
{
    public Animator anim;
    bool isKnocked = false;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            isKnocked = true;
            anim.SetBool("isKnocked", true);
        }
    }
}

