using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class NextLevel : MonoBehaviour
{
    private int sceneIndex;
    private GameManager gameManager;

    [Header("Audio Settings")]
    private AudioSource audioSource;
    public AudioClip scarySound;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(scarySound);
            gameManager.InstantiateBadCharacter(new Vector3(-0.1f, 1.85f, 76));
            StartCoroutine(gameManager.LoadNextSceneAfterDelay(0.5f));
        }
    }
}
