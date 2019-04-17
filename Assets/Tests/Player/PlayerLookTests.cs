using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

namespace Tests
{
    public class PlayerLookTests
    {
        
        [Test]
        public void PlayerLook_LookHorizontalAxis_ShouldRotate()
        {
            // Defines the expected values
            Vector3 expectedEulerAngle = new Vector3(0f, 1f, 0f);

            // Defining values os player movement
            float sensibility = 1f;
            Vector2 minimum = new Vector2(-360f, -360f);
            Vector2 maximum = new Vector2(360f, 360f);

            PlayerLook playerLook = new PlayerLook(Quaternion.identity, sensibility, minimum, maximum);

            // Call the player movement methods
            Quaternion result = playerLook.LookHorizontalAxis(1f);

            TestUtils.AreEqualFloat(expectedEulerAngle.x, result.eulerAngles.x);
            TestUtils.AreEqualFloat(expectedEulerAngle.y, result.eulerAngles.y);
            TestUtils.AreEqualFloat(expectedEulerAngle.z, result.eulerAngles.z);

        }
        
        [Test]
        public void PlayerLook_LookHorizontalAxis_ShouldRotate_Negative()
        {
            // Defines the expected values
            Vector3 expectedEulerAngle = new Vector3(0f, 359f, 0f);

            // Defining values os player movement
            float sensibility = 1f;
            Vector2 minimum = new Vector2(-360f, -360f);
            Vector2 maximum = new Vector2(360f, 360f);

            PlayerLook playerLook = new PlayerLook(Quaternion.identity, sensibility, minimum, maximum);

            // Call the player movement methods
            Quaternion result = playerLook.LookHorizontalAxis(-1f);

            TestUtils.AreEqualFloat(expectedEulerAngle.x, result.eulerAngles.x);
            TestUtils.AreEqualFloat(expectedEulerAngle.y, result.eulerAngles.y);
            TestUtils.AreEqualFloat(expectedEulerAngle.z, result.eulerAngles.z);

        }
        
        [Test]
        public void PlayerLook_LookHorizontalAxis_ShouldRotate_WithSensibility()
        {
            // Defines the expected values
            Vector3 expectedEulerAngle = new Vector3(0f, 10f, 0f);

            // Defining values os player movement
            float sensibility = 10f;
            Vector2 minimum = new Vector2(-360f, -360f);
            Vector2 maximum = new Vector2(360f, 360f);

            PlayerLook playerLook = new PlayerLook(Quaternion.identity, sensibility, minimum, maximum);

            // Call the player movement methods
            Quaternion result = playerLook.LookHorizontalAxis(1f);

            TestUtils.AreEqualFloat(expectedEulerAngle.x, result.eulerAngles.x);
            TestUtils.AreEqualFloat(expectedEulerAngle.y, result.eulerAngles.y);
            TestUtils.AreEqualFloat(expectedEulerAngle.z, result.eulerAngles.z);

        }
        
        [Test]
        public void PlayerLook_LookVerticalAxis_ShouldRotate()
        {
            // Defines the expected values
            Vector3 expectedEulerAngle = new Vector3(1f, 0f, 0f);

            // Defining values os player movement
            float sensibility = 1f;
            Vector2 minimum = new Vector2(-360f, -360f);
            Vector2 maximum = new Vector2(360f, 360f);

            PlayerLook playerLook = new PlayerLook(Quaternion.identity, sensibility, minimum, maximum);

            // Call the player movement methods
            Quaternion result = playerLook.LookVerticalAxis(-1f);

            TestUtils.AreEqualFloat(expectedEulerAngle.x, result.eulerAngles.x);
            TestUtils.AreEqualFloat(expectedEulerAngle.y, result.eulerAngles.y);
            TestUtils.AreEqualFloat(expectedEulerAngle.z, result.eulerAngles.z);

        }
        
        [Test]
        public void PlayerLook_LookVerticalAxis_ShouldRotate_WithSensibility()
        {
            // Defines the expected values
            Vector3 expectedEulerAngle = new Vector3(10f, 0f, 0f);

            // Defining values os player movement
            float sensibility = 10f;
            Vector2 minimum = new Vector2(-360f, -360f);
            Vector2 maximum = new Vector2(360f, 360f);

            PlayerLook playerLook = new PlayerLook(Quaternion.identity, sensibility, minimum, maximum);

            // Call the player movement methods
            Quaternion result = playerLook.LookVerticalAxis(-1f);

            TestUtils.AreEqualFloat(expectedEulerAngle.x, result.eulerAngles.x);
            TestUtils.AreEqualFloat(expectedEulerAngle.y, result.eulerAngles.y);
            TestUtils.AreEqualFloat(expectedEulerAngle.z, result.eulerAngles.z);

        }
        
        [Test]
        public void PlayerLook_LookVerticalAxis_ShouldRotate_Negative()
        {
            // Defines the expected values
            Vector3 expectedEulerAngle = new Vector3(359f, 0f, 0f);

            // Defining values os player movement
            float sensibility = 1f;
            Vector2 minimum = new Vector2(-360f, -360f);
            Vector2 maximum = new Vector2(360f, 360f);

            PlayerLook playerLook = new PlayerLook(Quaternion.identity, sensibility, minimum, maximum);

            // Call the player movement methods
            Quaternion result = playerLook.LookVerticalAxis(1f);

            TestUtils.AreEqualFloat(expectedEulerAngle.x, result.eulerAngles.x);
            TestUtils.AreEqualFloat(expectedEulerAngle.y, result.eulerAngles.y);
            TestUtils.AreEqualFloat(expectedEulerAngle.z, result.eulerAngles.z);

        }
        
    }
}
