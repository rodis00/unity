using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject badCharacter;
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
            Debug.Log("Player in finish");
            Instantiate(badCharacter, new Vector3(-0.1f, 1.85f, 76), Quaternion.identity).transform.Rotate(0, 180, 0);

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
