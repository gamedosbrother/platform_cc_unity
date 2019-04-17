using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
 
    [Header("Movement")]
    [SerializeField]
    private float gravity = 10f;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float acceleration;
    [Header("Jump")]
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private int airJumpsAmount = 1;
    [Header("Look")]
	[SerializeField]
    [Range(0f, 5f)]
    private float sensitivity = 3f;
	[SerializeField]
    private Vector2 minimum;
	[SerializeField]
    private Vector2 maximum;
    
    private PlayerMovement playerMovement;
    private PlayerLook playerLook;
    private IInputComponent inputComponent;

    private Camera camera;

    void Awake()
    {
        CharacterControllerWrapper characterControllerWrapper = new CharacterControllerWrapper(GetComponent<CharacterController>());
        camera = Camera.main;

        playerMovement = new PlayerMovement(characterControllerWrapper, moveSpeed, acceleration, jumpHeight, airJumpsAmount, gravity);
        playerLook = new PlayerLook(transform.rotation, sensitivity, minimum, maximum);
        inputComponent = new InputComponent();
    }

    void Update()
    {
        float verticalMovement = inputComponent.GetAxisRaw("Vertical");
        float horizontalMovement = inputComponent.GetAxisRaw("Horizontal");

        playerMovement.ApplyDirection((transform.forward * verticalMovement) + (transform.right * horizontalMovement));

        transform.localRotation = playerLook.LookHorizontalAxis(inputComponent.GetAxis("Mouse X"));
        camera.transform.localRotation = playerLook.LookVerticalAxis(inputComponent.GetAxis("Mouse Y"));

        if(inputComponent.GetKeyDown(KeyCode.Space))
        {
            playerMovement.Jump();
        }
    }

    void FixedUpdate()
    {
        playerMovement.Move(Time.fixedDeltaTime);
    }

}
