using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private bool shouldOpen = true;
    private bool playerOnTrigger = false;
    private float speed = 2f;

    public Transform endPoint;
    public Transform startPoint;

    public GameObject door;

    void Update()
    {
        if (playerOnTrigger)
        {
            if (door.transform.position != endPoint.position)
                door.transform.position = Vector3.MoveTowards(door.transform.position, endPoint.position, Time.deltaTime * speed);
        }
        else
        {
            if (door.transform.position != startPoint.position)
                door.transform.position = Vector3.MoveTowards(door.transform.position, startPoint.position, Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerOnTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerOnTrigger = false;
    }
}
