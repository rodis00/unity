using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    [Header("Time Settings")]
    public TextMeshProUGUI timeText;
    public float time;

    [Header("Level Settings")]
    public GameObject badCharacter;
    private int sceneIndex;

    [Header("Audio Settings")]
    private AudioSource audioSource;
    public AudioClip restartAudio;

    void Start()
    {
        Time.timeScale = 1f;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        audioSource = GetComponent<AudioSource>();
        UnityEngine.Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        time -= Time.deltaTime;
        timeText.text = "Time: " + Mathf.Clamp(Mathf.CeilToInt(time), 0, int.MaxValue).ToString();

        if (time <= 3)
        {
            timeText.color = Color.red;
            timeText.fontStyle = FontStyles.Bold;
            Time.timeScale = 0.5f;
        }
        if (time <= 0)
        {
            StartCoroutine(ResetLevelAfterDelay(1.2f));
            audioSource.PlayOneShot(restartAudio);
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

    private IEnumerator ResetLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        ResetLevel();
    }

    public void ReduceTime(float time)
    {
        this.time -= time;
        timeText.color = Color.red;
        StartCoroutine(ChangeFontColorDelay(.5f));
    }

    public void AddTime(float time)
    {
        this.time += time;
        timeText.color = Color.green;
        StartCoroutine(ChangeFontColorDelay(.5f));
        
    }

    IEnumerator ChangeFontColorDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        timeText.color = Color.white;
    }
}
