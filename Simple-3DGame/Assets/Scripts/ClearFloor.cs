using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class ClearFloor : MonoBehaviour
{
    private GameObject floor;
    private GameManager gameManager;
    private bool isCleared = false;
    private int sceneIndex;
    public TextMeshProUGUI objectsToDestroy;

    [Header("Audio Settings")]
    private AudioSource audioSource;
    public AudioClip scaryAudio;

    void Start()
    {
        floor = GameObject.FindWithTag("LevelObjects");
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        int floorChildren = GetChildrenCount(floor);
        Debug.Log("" + floorChildren + " - " + isCleared);
        
        if (floorChildren == 0)
        {
            isCleared = true;
        }
        objectsToDestroy.text = "Squares to remove: " + floorChildren.ToString();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isCleared)
        {
            audioSource.PlayOneShot(scaryAudio);
            gameManager.InstantiateBadCharacter(new Vector3(-0.1f, 1.85f, 76));
            gameManager.time += 3f;
            StartCoroutine(gameManager.LoadNextSceneAfterDelay(2f));
        }
    }

    private int GetChildrenCount(GameObject parent)
    {
        return parent.transform.childCount;
    }
}
