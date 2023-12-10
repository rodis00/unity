using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.SceneManagement;

public class ClearFloor : MonoBehaviour
{
    private GameObject floor;
    private GameManager gameManager;
    private bool isCleared = false;
    private int sceneIndex;
    public TextMeshProUGUI objectsToDestroy;

    void Start()
    {
        floor = GameObject.FindWithTag("LevelObjects");
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
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
            gameManager.InstantiateBadCharacter(new Vector3(-0.1f, 1.85f, 76));
            StartCoroutine(gameManager.LoadNextSceneAfterDelay(0.5f));
        }
    }

    private int GetChildrenCount(GameObject parent)
    {
        return parent.transform.childCount;
    }
}
