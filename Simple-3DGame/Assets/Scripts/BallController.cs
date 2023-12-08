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

        float directionH = Input.GetAxis("Horizontal");
        float directionV = Input.GetAxis("Vertical");

        if (directionH != 0)
        {
            rb.AddTorque(0, 0, -directionH * Time.deltaTime * speed);
        }
        if (directionV != 0)
        {
            rb.AddTorque(directionV * Time.deltaTime * speed, 0, 0);
        }

        if (transform.position.y <= -10f)
            manager.ResetLevel();
        
    }
}
