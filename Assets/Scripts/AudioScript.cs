using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    // Source
    public AudioSource music;

    [Header("Background Music")]
    public AudioClip bgMusic;

    private void Start()
    {
        // music.clip = bgMusic;
        // StartCoroutine(PlaySong(0.4f));

    }
    public void LoadAndSetBackgroundMusic(string path, float waitTime)
    {
        string audioPath = "Audio/" + path; // Relative path inside Resources (without extension)
        bgMusic = Resources.Load<AudioClip>(audioPath);

        if (bgMusic != null)
        {
            music = this.gameObject.GetComponent<AudioSource>();
            music.clip = bgMusic;
            play(waitTime);
            Debug.Log($"AudioClip '{audioPath}' successfully loaded and set.");
        }
        else
        {
            Debug.LogWarning($"AudioClip '{audioPath}' could not be found!");
        }
    }
    public void play(float waitTime)
    {
        StartCoroutine(PlaySong(waitTime));
    }
    public IEnumerator PlaySong(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        music.Play();
    }
}
