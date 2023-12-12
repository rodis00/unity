using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowItUp : MonoBehaviour
{
    public Rigidbody playerRb;
    private bool pushUp = false;
    private float height = .5f;

    private void Update()
    {
        if (pushUp)
            playerRb.AddForce(Vector3.up * height, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            pushUp = true;
    }
}
