using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovementController : MonoBehaviour {
    Rigidbody rb;
    [SerializeField] private float jumpForce = 344f;
    [SerializeField] private float moveSpeed = 34f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 3.6f;
    [SerializeField] private LayerMask groundMask;

    bool isGrounded;


    // Start is called before the first frame update

    void Awake() // Use Awake instead of Start
    {
        rb = GetComponent<Rigidbody>();

        // Check if Rigidbody was found
        if (rb == null) {
            Debug.LogError("Rigidbody component missing from this GameObject!");
            // Optionally, disable this script to prevent further errors:
            // this.enabled = false;
        }
    }


    // Update is called once per frame
    void Update() {
        // ABSTRACTION
        Jump();
        // Move Method Abstracted
        Move();
    }

    // Jump Method Defined
    public void Jump() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }
    }

    // Void Method Defined
    protected virtual void Move() {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, 0f);
        rb.velocity = moveDirection * moveSpeed;

    }
}
