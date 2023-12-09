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

    void Start()
    {
        Time.timeScale = 1f;
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
}
