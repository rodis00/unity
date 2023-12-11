using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ChangeColor : MonoBehaviour
{

    [Header("Cube lifes")]
    public int lives = 3;
    private MeshRenderer meshRenderer;

    [Header("Audio Settings")]
    private AudioSource audioSource;
    public AudioClip hitAudio;

    private GameManager gameManager;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(hitAudio);
            gameManager.AddTime(2f);

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
