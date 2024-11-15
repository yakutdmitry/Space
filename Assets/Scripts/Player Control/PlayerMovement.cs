using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Movement setup

    public string currentState;

    public float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float wallRunSpeed;

    public KeyCode sprintKey = KeyCode.LeftShift;

    public Transform Orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    //Apply resistance

    public float playerHeight;
    public float groundResistance;
    public LayerMask ground;
    public bool grounded;

    // Crouch Setup

    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;
    public KeyCode crouchKey = KeyCode.LeftControl;

    //Jump setup

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public KeyCode jumpKey = KeyCode.Space;
    bool canJump = true;

    //Wallrunning
    public bool wallrunning;

    //Slopes

    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    public MovementState state;

    public enum MovementState 
    {
        walking,
        sprinting,
        wallrunning,
        crouching,
        inAir
    }

    private void StateHandler()
    {
        //Sprinting
        if(grounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
        }
        //Walking
        else if (grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }
        //Crouching
        else if (Input.GetKey(crouchKey))
        {
            state = MovementState.crouching;
            moveSpeed = crouchSpeed;
        }
        //InAir
        else
        {
            state = MovementState.inAir;
        }

        if (wallrunning)
        {
            state = MovementState.wallrunning;

            moveSpeed = wallRunSpeed;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        startYScale = transform.localScale.y;
    }

    private void myInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpKey) && canJump && grounded)
        {
            canJump = false;

            Jump();

            Invoke(nameof(resetJump), jumpCooldown);
        }

        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }

        if (Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }
    }
    
    private void Update()
    {

        //Check if grounded by raycast

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);

        //Apply resistance to speed if grounded
        
        if (grounded == true)
        {
            rb.linearDamping = groundResistance;
        }
        else
        {
            rb.linearDamping = 0;
        }

        myInput();
        speedLimit();
        StateHandler();

        if(state == MovementState.inAir)
        {
            currentState = "In Air";
        }
        if (state == MovementState.walking)
        {
            currentState = "Walking";
        }
        if (state == MovementState.sprinting)
        {
            currentState = "Sprinting";
        }
        if (state == MovementState.crouching)
        {
            currentState = "Crouching";
        }
    }

    private void movePlayer()
    {
        //Set player to always move towards mouse

        moveDirection = Orientation.forward * verticalInput + Orientation.right * horizontalInput;

        //Move Player
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
        else if (onSlope() && !exitingSlope)
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);

            if (rb.linearVelocity.y > 0)
            {
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
            }
        }

        rb.useGravity = !onSlope();
    }

    void FixedUpdate()
    {
        movePlayer();
    }

    private void speedLimit()
    {
        //Slope Speed Limit
        if (onSlope() && !exitingSlope)
        {
            if(rb.linearVelocity.magnitude > moveSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * moveSpeed;
            }
        }
        else
        {
            //Get velocity of rigidbody

            Vector3 flatVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

            //Limit the velocity if it's greater than intended move speed

            if (flatVelocity.magnitude > moveSpeed)
            {
                Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
                rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);
            }
        }
    }

    private void Jump()
    {
        //Make y velocity = 0 so all jumps are same height
        exitingSlope = true;

        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.y);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void resetJump()
    {
        canJump = true;
        exitingSlope = false;
    }

    private bool onSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }
        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }
}
