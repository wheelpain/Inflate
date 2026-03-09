using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 6f;
    
    
    Rigidbody rb;
    private Vector3 input;

    //camera Rotation variables
    [SerializeField]
    GameObject cameraObject;

    public Transform cameraTransform;

    HeliTransform ballMode;

    public HeliumBar helium;

    //jumping falling tweaks
    public float fallMultiplier = 5f;
    public float lowJumpMultiplier = 4f;
    public float baseGravityScale = 2f;
    public float jumpForce = 15f;

    //jumping bool animation Triggers
    public Animator animator;

    public bool isGrounded;

    HeliTransform heliTransform;

    public SoundManager soundManager;

    public ParticleSystem fartParticle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ballMode = GetComponent<HeliTransform>();
        helium = GetComponent<HeliumBar>();
        heliTransform = GetComponent<HeliTransform>();
    }

    // Update is called once per frame
   
    //camera rotation
   

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            // Apply an upward force as an impulse
            //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isGrounded = false; // Reset the flag immediately
            if (ballMode.isBall == true)
            {
                helium.SpendHelium(10);
                soundManager.PlayPop();
            }
        }
    }

    public void Dash()
    {
               if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // Apply a forward force as an impulse
            Vector3 dashDirection = transform.forward; // Dash in the direction the player is facing
            rb.AddForce(dashDirection * moveSpeed * 10, ForceMode.Impulse);
            soundManager.PlayFart();
            helium.SpendHelium(30);
                fartParticle.Play();
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            isGrounded = true;
            

            //Debug.Log("isGrounded: " + isGrounded);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        input = new Vector3(h, 0f, v).normalized;
        
        // Get camera forward & right directions
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        // Ignore vertical tilt (prevents flying into ground)
        camForward.y = 0;
        camRight.y = 0;

        camForward.Normalize();
        camRight.Normalize();

        // Combine movement directions
        Vector3 moveDirection = camForward * v + camRight * h;

        // Move player
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Optional: Rotate player to face movement direction
        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }

       

        if (isGrounded)
        {
            Jump();

        }
        if(!isGrounded && ballMode.isBall == true)
        {
            Jump();
            Dash();
        }
    }
    private void FixedUpdate()
    {
        
        if (rb.velocity.y < 0 && ballMode.isHuman == true)
        {
            Debug.Log("fallSpeed");
            // Apply extra gravity when falling
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            // BASE GRAVITY: Applied during normal ascent
            rb.AddForce(Vector3.up * Physics.gravity.y * (baseGravityScale - 1), ForceMode.Acceleration);
        }
        else
        {
            // BASE GRAVITY: Applied during normal ascent
            rb.AddForce(Vector3.up * Physics.gravity.y * (baseGravityScale - 1), ForceMode.Acceleration);
        }
        
    }
}
