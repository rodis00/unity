using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 100f;
    public Rigidbody rb;
    public float maxAngularVelocity = 20f;

    private GameManager manager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxAngularVelocity;
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    void Update()
    {
        if (transform.position.y <= -10f)
            manager.ResetLevel();
    }

    private void FixedUpdate()
    {
        float directionH = Input.GetAxis("Horizontal");
        float directionV = Input.GetAxis("Vertical");

        if (directionH != 0)
            rb.AddTorque(0, 0, -directionH * Time.fixedDeltaTime * speed);

        if (directionV != 0)
            rb.AddTorque(directionV * Time.fixedDeltaTime * speed, 0, 0);
    }
}
