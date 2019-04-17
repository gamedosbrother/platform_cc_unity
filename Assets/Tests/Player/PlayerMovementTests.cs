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
            ICharacterControllerWrapper movementMock = Substitute.For<ICharacterControllerWrapper>();
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
            ICharacterControllerWrapper movementMock = Substitute.For<ICharacterControllerWrapper>();
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
            ICharacterControllerWrapper movementMock = Substitute.For<ICharacterControllerWrapper>();
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
            ICharacterControllerWrapper movementMock = Substitute.For<ICharacterControllerWrapper>();
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
            ICharacterControllerWrapper movementMock = Substitute.For<ICharacterControllerWrapper>();

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
        
        [Test]
        public void PlayerMovement_Jump_ShouldSetVelocity_ToJumpForce()
        {
            // Defines the expected values
            // jumpForce = SQRT( jumpHeight * 2 * gravity )
            float expectedJumpForce = Mathf.Sqrt(1f * 2f * 10f);
            Vector3 expectedMotion = new Vector3(0f, expectedJumpForce - 10f, 0f);

            // Mocking MovementComponent
            ICharacterControllerWrapper movementMock = Substitute.For<ICharacterControllerWrapper>();

            // Defining values os player movement
            float jumpHeight = 1f;
            float gravity = 10f;
            PlayerMovement playerMovement = new PlayerMovement(movementMock, 0f, 0f, jumpHeight, 0, gravity);

            // Call the player movement methods
            movementMock.IsGrounded.Returns(true);
            playerMovement.Jump();

            playerMovement.Move(1f);
            movementMock.Received().Move(expectedMotion);

        }
        
        [Test]
        public void PlayerMovement_Jump_ShouldNotJump_IfNotGrounded()
        {
            // Defines the expected values
            // jumpForce = SQRT( jumpHeight * 2 * gravity )
            float expectedJumpForce = Mathf.Sqrt(1f * 2f * 10f);
            Vector3 expectedMotion = new Vector3(0f, -10f, 0f);

            // Mocking MovementComponent
            ICharacterControllerWrapper movementMock = Substitute.For<ICharacterControllerWrapper>();

            // Defining values os player movement
            float jumpHeight = 1f;
            float gravity = 10f;
            PlayerMovement playerMovement = new PlayerMovement(movementMock, 0f, 0f, jumpHeight, 0, gravity);

            // Call the player movement methods
            movementMock.IsGrounded.Returns(false);
            playerMovement.Jump();

            playerMovement.Move(1f);
            movementMock.Received().Move(expectedMotion);

        }
        
        [Test]
        public void PlayerMovement_Jump_ShouldApply_Gravity()
        {
            // Defines the expected values
            // jumpForce = SQRT( jumpHeight * 2 * gravity )
            float expectedJumpForce = Mathf.Sqrt(1f * 2f * 10f);
            Vector3 expectedMotion = new Vector3(0f, expectedJumpForce - 10f, 0f);
            Vector3 expectedGravityMotion = new Vector3(0f, expectedJumpForce - 20f, 0f);

            // Mocking MovementComponent
            ICharacterControllerWrapper movementMock = Substitute.For<ICharacterControllerWrapper>();

            // Defining values os player movement
            float jumpHeight = 1f;
            float gravity = 10f;
            PlayerMovement playerMovement = new PlayerMovement(movementMock, 0f, 0f, jumpHeight, 0, gravity);

            // Call the player movement methods
            movementMock.IsGrounded.Returns(true);
            playerMovement.Jump();

            playerMovement.Move(1f);
            movementMock.Received().Move(expectedMotion);

            playerMovement.Move(1f);
            movementMock.Received().Move(expectedMotion);

        }
        
    }
}
