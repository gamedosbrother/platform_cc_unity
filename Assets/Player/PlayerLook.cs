using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

	[SerializeField]
    [Range(0f, 5f)]
    private float sensitivity = 3f;
	[SerializeField]
    private Vector2 minimum;
	[SerializeField]
    private Vector2 maximum;

	private Vector2 rotation;
	private Quaternion originalRotation;

	private Camera camera;

    void Awake()
    {
        originalRotation = transform.rotation;
		Cursor.lockState = CursorLockMode.None;
        
        camera = Camera.main;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown (KeyCode.P)) {
			if (Cursor.lockState == CursorLockMode.Locked) Cursor.lockState = CursorLockMode.None;
			else Cursor.lockState = CursorLockMode.Locked;
		}
        
		// Read the mouse input axis
		rotation.x += Input.GetAxis ("Mouse X") * sensitivity;
		rotation.y += Input.GetAxis ("Mouse Y") * sensitivity;

		rotation.x = ClampAngle (rotation.x, minimum.x, maximum.x);
		rotation.y = ClampAngle (rotation.y, minimum.y, maximum.y);

		Quaternion xQuaternion = Quaternion.AngleAxis (rotation.x, Vector3.up);
		Quaternion yQuaternion = Quaternion.AngleAxis (rotation.y, -Vector3.right);

		transform.localRotation = originalRotation * xQuaternion;
		camera.transform.localRotation = originalRotation * yQuaternion;
    }

	float ClampAngle (float angle, float min, float max)
    {
		if (angle < -360f) angle += 360f;
		if (angle > 360f) angle -= 360f;
		return Mathf.Clamp (angle, min, max);
	}

}
