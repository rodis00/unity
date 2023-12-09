using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private int sceneIndex;
    private GameManager manager;
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.InstantiateBadCharacter(new Vector3(-0.1f, 1.85f, 76));
            StartCoroutine(LoadNextSceneAfterDelay(0.5f));
        }
    }

    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (SceneManager.sceneCountInBuildSettings > sceneIndex + 1)
        {
            manager.LoadNextScene(sceneIndex + 1);
        }
        else
        {
            manager.LoadFirstScene();
        }
    }
}
