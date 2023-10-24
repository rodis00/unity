using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad_2 : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector3 startPosition;
    private bool moveRight = true;

    void Start()
    {
        startPosition = transform.position;
    }


    void Update()
    {
        if (moveRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            if (transform.position.x >= startPosition.x + 10)
            {
                moveRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x <= startPosition.x)
            {
                moveRight = true;
            }
        }
    }
}
