using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DestroyObject : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioClip hitAudio;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();    
    }
    void Update()
    {
        if (transform.position.y <= -5f)
            Destroy(this.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(hitAudio);
        }
    }
}
