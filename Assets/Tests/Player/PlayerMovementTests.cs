using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

namespace Tests
{
    public class PlayerMovementTests
    {
        
        [Test]
        public void PlayerMovement_Move_ShouldMoveToDirection()
        {
            // Defines the expected values
            Vector3 expectedMoveMotion = new Vector3(1f, -10f, 1f);

            // Mocking MovementComponent
            IMovementComponent movementMock = Substitute.For<IMovementComponent>();
            movementMock.IsGrounded.Returns(true);

            // Defining values os player movement
            float playerMoveSpeed = 1f;
            float playerAcceleration = 10f;

            PlayerMovement playerMovement = new PlayerMovement(movementMock, playerMoveSpeed, playerAcceleration, 0f, 0);

            // Call the player movement methods
            playerMovement.ApplyDirection(Vector3.one);
            playerMovement.Move(1f);

            // Check the methods calls on mock
            movementMock.Received().Move(expectedMoveMotion);
        }
        
        [Test]
        public void PlayerMovement_Move_ShouldApplyGravityEachMoveCall_WhenNotGrounded()
        {
            // Defines the expected values
            Vector3 expectedFirstMoveMotion = new Vector3(0f, -10f, 0f);
            Vector3 expectedSecondMoveMotion = new Vector3(0f, -20f, 0f);

            // Mocking MovementComponent
            IMovementComponent movementMock = Substitute.For<IMovementComponent>();
            movementMock.IsGrounded.Returns(false);

            // Defining values os player movement
            float playerMoveSpeed = 0f;
            float playerAcceleration = 0f;

            PlayerMovement playerMovement = new PlayerMovement(movementMock, playerMoveSpeed, playerAcceleration, 0f, 0);

            // Call the player movement methods
            playerMovement.ApplyDirection(Vector3.one);

            playerMovement.Move(1f);
            movementMock.Received().Move(expectedFirstMoveMotion);

            playerMovement.Move(1f);
            movementMock.Received().Move(expectedSecondMoveMotion);
        }
        
        [Test]
        public void PlayerMovement_Move_ShouldMoveToDirection_RelativeToDeltaTime()
        {
            // Defines the expected values
            Vector3 expectedMoveMotion = new Vector3(.5f, -2.5f, .5f);

            // Mocking MovementComponent
            IMovementComponent movementMock = Substitute.For<IMovementComponent>();
            movementMock.IsGrounded.Returns(true);

            // Defining values os player movement
            float playerMoveSpeed = 1f;
            float playerAcceleration = 10f;

            PlayerMovement playerMovement = new PlayerMovement(movementMock, playerMoveSpeed, playerAcceleration, 0f, 0);

            // Call the player movement methods
            playerMovement.ApplyDirection(Vector3.one);
            playerMovement.Move(.5f);

            // Check the methods calls on mock
            movementMock.Received().Move(expectedMoveMotion);
        }
        
        [Test]
        public void PlayerMovement_Move_IncreaseTheVelocity_WithAcceleration()
        {
            // Defines the expected values
            Vector3 expectedFirstMoveMotion = new Vector3(.5f, -10f, 0f);

            // Mocking MovementComponent
            IMovementComponent movementMock = Substitute.For<IMovementComponent>();
            movementMock.IsGrounded.Returns(true);

            // Defining values os player movement
            float playerMoveSpeed = 1f;
            float playerAcceleration = .5f;

            PlayerMovement playerMovement = new PlayerMovement(movementMock, playerMoveSpeed, playerAcceleration, 0f, 0);

            // Call the player movement methods
            playerMovement.ApplyDirection(new Vector3(1f, 0f, 0f));

            playerMovement.Move(1f);
            movementMock.Received().Move(expectedFirstMoveMotion);
        }
        
        [Test]
        public void PlayerMovement_Move_ShouldResetGravity_WhenGrounded()
        {
            // Defines the expected values
            Vector3 expectedFirstMoveMotion = new Vector3(0f, -10f, 0f);
            Vector3 expectedSecondMoveMotion = new Vector3(0f, -20f, 0f);
            Vector3 expectedThirdMoveMotion = new Vector3(0f, -10f, 0f);

            // Mocking MovementComponent
            IMovementComponent movementMock = Substitute.For<IMovementComponent>();

            // Defining values os player movement
            float playerMoveSpeed = 0f;
            float playerAcceleration = 0f;

            PlayerMovement playerMovement = new PlayerMovement(movementMock, playerMoveSpeed, playerAcceleration, 0f, 0);

            // Call the player movement methods
            playerMovement.ApplyDirection(Vector3.one);

            playerMovement.Move(1f);
            movementMock.IsGrounded.Returns(false);
            movementMock.Received().Move(expectedFirstMoveMotion);

            playerMovement.Move(1f);
            movementMock.IsGrounded.Returns(false);
            movementMock.Received().Move(expectedSecondMoveMotion);

            playerMovement.Move(1f);
            movementMock.IsGrounded.Returns(true);
            movementMock.Received().Move(expectedThirdMoveMotion);
        }
        
    }
}
