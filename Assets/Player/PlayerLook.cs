using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook
{

    private float sensitivity;
    private Vector2 minimum;
    private Vector2 maximum;

	private Vector2 rotation;
	private Quaternion originalRotation;

    public PlayerLook(Quaternion _originalRotation, float _sensitivity, Vector2 _minimum, Vector2 _maximum)
    {
        originalRotation = _originalRotation;
		sensitivity = _sensitivity;
		minimum = _minimum;
		maximum = _maximum;
    }

    public Quaternion LookHorizontalAxis(float movement)
    {
		rotation.x += movement * sensitivity;
		rotation.x = ClampAngle (rotation.x, minimum.x, maximum.x);
		Quaternion xQuaternion = Quaternion.AngleAxis (rotation.x, Vector3.up);
		
		return originalRotation * xQuaternion;
    }

    public Quaternion LookVerticalAxis(float movement)
    {
		rotation.y += movement * sensitivity;
		rotation.y = ClampAngle (rotation.y, minimum.y, maximum.y);
		Quaternion yQuaternion = Quaternion.AngleAxis (rotation.y, -Vector3.right);

		return originalRotation * yQuaternion;
    }

	float ClampAngle (float angle, float min, float max)
    {
		if (angle < -360f) angle += 360f;
		if (angle > 360f) angle -= 360f;
		return Mathf.Clamp (angle, min, max);
	}

}
