using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class VRPlayerController : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction rotateAction;

    private Vector2 moveInput;
    private Vector2 lookInput;

    private Transform playerCamera;
    private float rotationSpeed = 100f;

    void Start()
    {
        // Get reference to the player's camera
        playerCamera = Camera.main.transform;

        // Get references to the input actions
        moveAction = new InputAction("Move", binding: "<XRController>{LeftHand}/thumbstick");
        rotateAction = new InputAction("Look", binding: "<XRController>{RightHand}/thumbstick");

        // Enable actions
        moveAction.Enable();
        rotateAction.Enable();
    }

    void Update()
    {
        // Get the movement input
        moveInput = moveAction.ReadValue<Vector2>();

        // Get the rotation input
        lookInput = rotateAction.ReadValue<Vector2>();

        // Move the player
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y) * Time.deltaTime * 3f;
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
    }
}
