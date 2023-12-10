using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollision : MonoBehaviour
{
    public float force = 500f;
    private GameObject ball;

    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody ballRb = ball.GetComponent<Rigidbody>();
            ballRb.AddForce(transform.forward * Time.deltaTime * force, ForceMode.Impulse);
        }
    }
}
