using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GreenIsOn : MonoBehaviour
{
    private GameObject levelObjects;
    private bool isGreenOn = false;

    private GameManager gameManager;
    private Color correctColor = new Color(0f, 1f, 0f);

    [Header("Audio Settings")]
    private AudioSource audioSource;
    public AudioClip scaryAudio;

    void Start()
    {
        levelObjects = GameObject.FindGameObjectWithTag("LevelObjects");
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        foreach (Transform child in levelObjects.transform)
        {
            Color childBG = child.GetComponent<MeshRenderer>().material.color;
            if (childBG.Compare(correctColor))
                isGreenOn = true;
            else
                isGreenOn = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isGreenOn)
        {
            audioSource.PlayOneShot(scaryAudio);
            gameManager.InstantiateBadCharacter(new Vector3(-0.1f, 1.85f, 76));
            StartCoroutine(gameManager.LoadNextSceneAfterDelay(.5f));
        }
    }
}
