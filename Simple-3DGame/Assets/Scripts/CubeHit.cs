using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CubeHit : MonoBehaviour
{
    [Header("Audio Settings")]
    private AudioSource audioSource;
    public AudioClip hitAudio;

    private GameManager gameManager;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(hitAudio);
            gameManager.ReduceTime(1f);
        }
    }
}
