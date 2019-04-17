using UnityEngine;

public class CharacterControllerWrapper : ICharacterControllerWrapper
{

    private CharacterController characterController;

    public bool IsGrounded { get { return characterController.isGrounded; } }

    public CharacterControllerWrapper(CharacterController _characterController)
    {
        characterController = _characterController;
    }

    public void Move(Vector3 motion)
    {
        characterController.Move(motion);
    }
}