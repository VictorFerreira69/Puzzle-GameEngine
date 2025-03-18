using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamaManagerMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] musicClips;

    private void Awake()
    {
      
        if (FindObjectsOfType<GamaManagerMusic >().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int sceneIndex = scene.buildIndex;

        if (sceneIndex < musicClips.Length && musicClips[sceneIndex] != null)
        {
            audioSource.clip = musicClips[sceneIndex];
            audioSource.Play();
        }
    }
}