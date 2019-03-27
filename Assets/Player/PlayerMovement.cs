using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 
    [Header("Movement")]
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float acceleration;
    [Header("Jump")]
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private int airJumpsAmount = 1;

    private float gravity;

    private float jumpForce;
    private int airJumpsPerformed = 0;

    private Vector3 targetMoveVelocity;
    private Vector3 moveVelocity;

    private float verticalSpeed;

    private CharacterController characterController;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();

        gravity = 10f;
        jumpForce = Mathf.Sqrt(jumpHeight * 2f * gravity);
    }

    void Update()
    {
        float verticalMovement = Input.GetAxisRaw("Vertical");
        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        targetMoveVelocity = (transform.forward * moveSpeed * verticalMovement) + (transform.right * moveSpeed * horizontalMovement);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(characterController.isGrounded)
            {
                Jump();
            }
            else if(++airJumpsPerformed <= airJumpsAmount)
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        verticalSpeed = jumpForce;
    }

    void FixedUpdate()
    {
        moveVelocity = Vector3.MoveTowards(moveVelocity, targetMoveVelocity, acceleration * Time.fixedDeltaTime);

        verticalSpeed -= gravity * Time.fixedDeltaTime;

        Vector3 velocity = moveVelocity;
        velocity.y = verticalSpeed;

        characterController.Move(velocity * Time.fixedDeltaTime);

        if(characterController.isGrounded)
        {
            verticalSpeed = 0f;
            airJumpsPerformed = 0;
        }
    }

}
