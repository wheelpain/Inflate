using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public bool isWalking;
    
    public enum CharacterState
    {
        Idle,
        Walking,
        Running,
        Jumping,
        Falling,
        Attacking
    }

    // Expose current state and optional Animator to drive animation parameters
    public CharacterState currentState = CharacterState.Idle;
    public Animator animator;

    // Call this to set walking on/off (updates state, flag and animator)
    public void SetWalking(bool walking)
    {
        isWalking = walking;
        currentState = walking ? CharacterState.Walking : CharacterState.Idle;

        if (animator != null)
        {
            // Assumes your Animator has a boolean parameter named "isWalking"
            animator.SetBool("isWalking", walking);
        }
    }

    // Convenience methods
    //public void StartWalking() => SetWalking(true);
    //public void StopWalking() => SetWalking(false);
    //public void ToggleWalking() => SetWalking(!isWalking);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame (example usage: toggle with W key)
    void Update()
    {

        // Example input-driven usage; remove or adapt to your input system
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            //StartWalking();
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("isWalking", false);
        } 
    }

}