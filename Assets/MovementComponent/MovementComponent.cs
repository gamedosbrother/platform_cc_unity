using UnityEngine;

public class MovementComponent : IMovementComponent
{

    private CharacterController characterController;

    public bool IsGrounded { get { return characterController.isGrounded; } }

    public MovementComponent(CharacterController _characterController)
    {
        characterController = _characterController;
    }

    public void Move(Vector3 motion)
    {
        characterController.Move(motion);
    }
}