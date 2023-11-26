using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeboxController : MonoBehaviour
{
    public List<AudioClip> musicList = new List<AudioClip>(); // Lista de músicas
    private AudioSource audioSource;
    private AudioClip currentClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayRandomMusic();
    }

    void PlayRandomMusic()
    {
        AudioClip nextClip = GetRandomClip();
        while (nextClip == currentClip && musicList.Count > 1)
        {
            nextClip = GetRandomClip();
        }

        currentClip = nextClip;
        audioSource.clip = currentClip;
        audioSource.Play();

        Invoke("PlayRandomMusic", currentClip.length);
    }

    AudioClip GetRandomClip()
    {
        int randomIndex = Random.Range(0, musicList.Count);
        return musicList[randomIndex];
    }
}
