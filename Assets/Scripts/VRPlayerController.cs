using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class VRPlayerController : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction rotateAction;
    private InputAction sprintAction; // Added sprint action

    private Vector2 moveInput;
    private Vector2 lookInput;

    private Transform playerCamera;
    private float rotationSpeed = 100f;

    public float walkSpeed = 3f;   // Normal speed
    public float sprintSpeed = 6f; // Sprint speed
    private float currentSpeed;

    void Start()
    {
        // Get reference to the player's camera
        playerCamera = Camera.main.transform;

        // Get references to the input actions
        moveAction = new InputAction("Move", binding: "<XRController>{LeftHand}/thumbstick");
        rotateAction = new InputAction("Look", binding: "<XRController>{RightHand}/thumbstick");
        sprintAction = new InputAction("Sprint", binding: "<XRController>{LeftHand}/trigger"); // Bind sprint to trigger

        // Enable actions
        moveAction.Enable();
        rotateAction.Enable();
        sprintAction.Enable(); // Enable sprint action

        currentSpeed = walkSpeed; // Initialize current speed
    }

    void Update()
    {
        // Get the sprint input
        bool isSprinting = sprintAction.ReadValue<float>() > 0.5f; // Trigger is analog, check for press
        currentSpeed = isSprinting ? sprintSpeed : walkSpeed;

        // Get the movement input
        moveInput = moveAction.ReadValue<Vector2>();

        // Get the rotation input
        lookInput = rotateAction.ReadValue<Vector2>();

        // Move the player
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y) * Time.deltaTime * currentSpeed;
        transform.Translate(move, Space.Self);

        // Rotate the player
        float yaw = lookInput.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(0f, yaw, 0f);
    }

    private void OnDisable()
    {
        // Disable actions when not in use
        moveAction.Disable();
        rotateAction.Disable();
        sprintAction.Disable();
    }
}
