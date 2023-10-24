using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad_3 : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }


    void Update()
    {
        if (Vector3.Distance(startPosition, transform.position) >= 10)
        {
            startPosition = transform.position;
            transform.Rotate(0, 90, 0);
        }
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
