using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private GameObject badCharacter;
    private int sceneIndex;
    private GameManager manager;
    void Start()
    {
        badCharacter = GameObject.FindGameObjectWithTag("BadCharacter");
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player in finish");
            badCharacter.transform.Translate(0, 5f, 0);

            StartCoroutine(LoadNextSceneAfterDelay(2f));
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
