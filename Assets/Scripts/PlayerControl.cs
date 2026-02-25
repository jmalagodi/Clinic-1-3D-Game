using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;
<<<<<<< Updated upstream
    public float gravity = -10f; 
=======
    public float gravity = -9.81f; 
>>>>>>> Stashed changes

    public float mouseSensitivity = 1f;
    public Transform cameraPivot;

    private CharacterController controller;
    private float xRotation = 0f;
<<<<<<< Updated upstream
    private float yVelocity = 0f;
=======
    private float yVelocity = 0f;   
>>>>>>> Stashed changes

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
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
<<<<<<< Updated upstream
       
=======

>>>>>>> Stashed changes
        if (move.magnitude > 1f)
            move.Normalize();

        if (controller.isGrounded && yVelocity < 0)
<<<<<<< Updated upstream
            yVelocity = 0f;   
=======
            yVelocity = 0f;  
>>>>>>> Stashed changes

        yVelocity += gravity * Time.deltaTime;

        Vector3 velocity = move * moveSpeed;
        velocity.y = yVelocity;

        controller.Move(velocity * Time.deltaTime);
    }
}
