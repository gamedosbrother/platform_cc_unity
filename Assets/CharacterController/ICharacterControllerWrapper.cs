using UnityEngine;

public interface ICharacterControllerWrapper
{
    bool IsGrounded { get; }
    void Move(Vector3 velocity);
}