using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    
    private float moveSpeed = 5;
    private float acceleration = 25;

    private float jumpHeight = 2;
    private int airJumpsAmount = 1;

    private float gravity;

    private float jumpForce;
    private int airJumpsPerformed = 0;

    private Vector3 targetMoveVelocity;
    private Vector3 moveVelocity;

    private float verticalSpeed;

    private ICharacterControllerWrapper characterController;

    public PlayerMovement(ICharacterControllerWrapper _characterController, float _moveSpeed, float _acceleration, float _jumpHeight, int _airJumpsAmount, float _gravity = 10f)
    {
        characterController = _characterController;
        
        moveSpeed = _moveSpeed;
        acceleration = _acceleration;
        jumpHeight = _jumpHeight;
        airJumpsAmount = _airJumpsAmount;

        gravity = _gravity;
        jumpForce = Mathf.Sqrt(jumpHeight * 2f * gravity);
    }

    public void ApplyDirection(Vector3 direction)
    {
        targetMoveVelocity = direction * moveSpeed;
    }

    public void Move(float deltaTime)
    {
        moveVelocity = Vector3.MoveTowards(moveVelocity, targetMoveVelocity, acceleration * deltaTime);

        verticalSpeed -= gravity * deltaTime;

        Vector3 velocity = moveVelocity;
        velocity.y = verticalSpeed;

        characterController.Move(velocity * deltaTime);

        if(characterController.IsGrounded)
        {
            verticalSpeed = 0f;
        }
    }

    public void Jump()
    {
        if(characterController.IsGrounded)
        {
            verticalSpeed = jumpForce;
        }
    }

}