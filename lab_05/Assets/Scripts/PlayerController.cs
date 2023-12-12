using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isGrounded = true;
    private float playerSpeed = 5.0f;
    private float jumpHeight = 1.0f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if (moveX != 0)
        {
            transform.Translate(moveX * Time.deltaTime * playerSpeed, 0, 0);
        }
        if (moveZ != 0)
        {
            transform.Translate(0, 0, moveZ * Time.deltaTime * playerSpeed);
        }
        
        if (Input.GetKey(KeyCode.Space) && !isGrounded)
        {
            transform.Translate(0f, jumpHeight * Time.deltaTime * playerSpeed, 0f);
        }

        if (transform.position.y > 1)
            isGrounded = false;
        else
            isGrounded = true;
    }
}
