using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject ball;
    public Vector3 cameraDistance = new Vector3(0, 3.5f, -3.5f);
    public float lookUp = -20;

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        transform.position = ball.transform.position + cameraDistance;
        transform.LookAt(ball.transform.position);
        transform.Rotate(lookUp, 0, 0);
    }
}
