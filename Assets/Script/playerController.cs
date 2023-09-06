using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;

    private Vector3 moveDirection;
    private Rigidbody rb;

    private float rotationX = 0;
    private float rotationY = 0; // Nueva variable para la rotación en Y

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Movimiento del jugador
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // Rotación del jugador con el mouse
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationX -= mouseY * mouseSensitivity;
        rotationX = Mathf.Clamp(rotationX, -90, 90);

        // Nueva rotación en Y
        rotationY += mouseX * mouseSensitivity;

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0); // Aplicar rotación en X y Y al jugador
    }

    void FixedUpdate()
    {
        // Aplicar movimiento al Rigidbody del jugador
        Vector3 velocity = transform.TransformDirection(moveDirection) * moveSpeed;
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }
}
