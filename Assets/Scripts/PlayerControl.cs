using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float gravity = -9.81f;  // Gravity value

    [Header("Mouse Look")]
    public float mouseSensitivity = 1f;
    public Transform cameraPivot;

    private CharacterController controller;
    private float xRotation = 0f;
    private float yVelocity = 0f;   // Vertical speed

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }

    private void HandleMovement()
    {
        // Get input
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        // Normalize diagonal movement
        if (move.magnitude > 1f)
            move.Normalize();

        // Apply gravity
        if (controller.isGrounded && yVelocity < 0)
            yVelocity = 0f;   // Reset vertical speed when grounded

        yVelocity += gravity * Time.deltaTime;

        // Add vertical velocity to movement
        Vector3 velocity = move * moveSpeed;
        velocity.y = yVelocity;

        controller.Move(velocity * Time.deltaTime);
    }
}
