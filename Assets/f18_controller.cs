using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class f18_controller : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public float jumpForce = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from the keyboard
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction based on user input
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // Rotate the object to face the mouse cursor
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // RaycastHit hit;

        // if (Physics.Raycast(ray, out hit))
        // {
        //     Vector3 lookAtPoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        //     transform.LookAt(lookAtPoint);
        // }

        // Apply forward force for movement
        Vector3 forwardForce = transform.forward * moveSpeed;
        rb.AddForce(forwardForce);

        // Apply upward force for flying
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
