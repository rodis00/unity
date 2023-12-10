using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Time Settings")]
    public TextMeshProUGUI timeText;
    public float time;

    [Header("Level Settings")]
    public GameObject badCharacter;
    private int sceneIndex;

    void Start()
    {
        Time.timeScale = 1f;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        time -= Time.deltaTime;
        timeText.text = "Time: " + Mathf.CeilToInt(time).ToString();

        if (time <= 3)
        {
            timeText.color = Color.red;
            timeText.fontStyle = FontStyles.Bold;
            Time.timeScale = 0.5f;
        }
        if (time <= 0)
        {
            ResetLevel();
        }
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }

    public void InstantiateBadCharacter(Vector3 position)
    {
        Instantiate(badCharacter, position, Quaternion.identity).transform.Rotate(0, 180, 0);
    }

    public IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (SceneManager.sceneCountInBuildSettings > sceneIndex + 1)
        {
            LoadNextScene(sceneIndex + 1);
        }
        else
        {
            LoadFirstScene();
        }
    }
}
