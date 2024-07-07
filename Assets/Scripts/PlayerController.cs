using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody rb;
    [SerializeField] private float jumpForce = 344f;
    [SerializeField] private float moveSpeed = 77f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 3.6f;
    [SerializeField] private LayerMask groundMask;

    bool isGrounded;


    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        // Jump Method Abstracted
        Jump();
        // Move Method Abstracted
        Move();
    }

    // Jump Method Defined
    void Jump() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }
    }

    // Void Method Defined
    void Move() {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, 0f);
        rb.velocity = moveDirection * moveSpeed;

    }
}
