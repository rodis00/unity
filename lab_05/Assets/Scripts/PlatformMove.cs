using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1f;
    private Transform target;

    private bool shouldGo = false;

    void Start()
    {
        target = endPoint;
    }

    
    void Update()
    {
        if (shouldGo)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);

            if (transform.position == endPoint.position)
            {
                target = startPoint;
            }
            if (transform.position == startPoint.position)
            {
                target = endPoint;
            }
                

        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player on platform");
            shouldGo = true;
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player on platform");
            shouldGo = false;
            collision.transform.parent = null;
        }
    }
}
