using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public float time;
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
}
