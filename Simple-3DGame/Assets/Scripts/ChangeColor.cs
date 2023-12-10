using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public int lives = 3;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (lives == 1)
                lives = 3;
            else
                lives -= 1;
        }
        
    }

    private void Update()
    {
        switch (lives)
        {
            case 3:
                meshRenderer.material.color = new Color(1f, 0f, 0f);
                break;
            case 2:
                meshRenderer.material.color = new Color(1f, .5f, 0f);
                break;
            case 1:
                meshRenderer.material.color = new Color(0f, 1f, 0f);
                break;
        }
    }
}
