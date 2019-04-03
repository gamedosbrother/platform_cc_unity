using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
 
    [Header("Movement")]
    [SerializeField]
    private float gravity = 10f;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float acceleration;
    [Header("Jump")]
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private int airJumpsAmount = 1;
    
    private PlayerMovement playerMovement;

    void Awake()
    {
        MovementComponent movementComponent = new MovementComponent(GetComponent<CharacterController>());

        playerMovement = new PlayerMovement(movementComponent, moveSpeed, acceleration, jumpHeight, airJumpsAmount, gravity);
    }

    void Update()
    {
        float verticalMovement = Input.GetAxisRaw("Vertical");
        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        playerMovement.ApplyDirection((transform.forward * verticalMovement) + (transform.right * horizontalMovement));
    }

    void FixedUpdate()
    {
        playerMovement.Move(Time.fixedDeltaTime);
    }

}
