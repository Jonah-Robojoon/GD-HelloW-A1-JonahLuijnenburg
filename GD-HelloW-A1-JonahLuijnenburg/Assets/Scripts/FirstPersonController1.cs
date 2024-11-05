using JetBrains.Annotations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FirstPersonController1 : MonoBehaviour
{
    public float WalkSpeed = 5f;
    public float SprintMulti = 2f;
    public float Jumpforce = 5f;
    public float GroundCheckDistance = 1.5f;
    public float LoofSenseX = 1f;
    public float LoofSenseY = 1f;
    public float MinYLookAngle = -90f;
    public float MaxYLookAngle = 90f;
    public float Gravity = -9.8f;
    private Vector3 velocity;
    private float verticalRotation = 0f;
    public Transform PlayerCamera;
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float HorizantalMovement = Input.GetAxis("Horizontal");
        float VerticalMovement = Input.GetAxis("Vertical");

        Vector3 MoveDirection = transform.forward * VerticalMovement + transform.right * HorizantalMovement;
        MoveDirection.Normalize();

        float speed = WalkSpeed;
        if (Input.GetAxis("Sprint") > 0)
        {
            speed *= SprintMulti;
        }

        characterController.Move(MoveDirection * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            velocity.y = Jumpforce;
        }
        else
        {
            velocity.y += Gravity * Time.deltaTime;
        }

        characterController.Move(velocity * Time.deltaTime);

        if (PlayerCamera != null)
        {
            float mouseX = Input.GetAxis("Mouse X") * LoofSenseX;
            float mouseY = Input.GetAxis("Mouse Y") * LoofSenseY;

            verticalRotation -= mouseY;
            verticalRotation = Mathf.Clamp(verticalRotation, MinYLookAngle, MaxYLookAngle);

            PlayerCamera.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
    }

    bool IsGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, GroundCheckDistance))
        {
            return true;
        }
        return false;
    }
}
