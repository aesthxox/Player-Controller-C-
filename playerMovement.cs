using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class playerMovement : MonoBehaviour
    {
    public Transform orientation;
    public float moveSpeed;
    float horizontalInput;
    float verticalInput;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    Vector3 direction;
    public Rigidbody rb;

    void Start()
    {
        //Gives body mass and force
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

        //lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        MyInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        isGrounded = true;
    }

    //Key Input
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    //updates player direction and adjusts movement 
    private void MovePlayer()
    {
        direction = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(direction.normalized * moveSpeed * 10f, ForceMode.Force);

        // jump controller
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}