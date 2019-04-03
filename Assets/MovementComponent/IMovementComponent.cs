using UnityEngine;

public interface IMovementComponent
{
    bool IsGrounded { get; }
    void Move(Vector3 velocity);
}