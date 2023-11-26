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
        if (musicList.Count > 0)
        {
            PlayRandomMusic();
        }
        else
        {
            Debug.LogWarning("A lista de clipes de áudio está vazia.");
        }
    }

    void PlayRandomMusic()
    {
        if (musicList.Count > 1)
        {
            AudioClip nextClip = GetRandomClip();
            while (nextClip == currentClip)
            {
                nextClip = GetRandomClip();
            }

            currentClip = nextClip;
            audioSource.clip = currentClip;
            audioSource.Play();

            Invoke("PlayRandomMusic", currentClip.length);
        }
        else if (musicList.Count == 1)
        {
            currentClip = musicList[0];
            audioSource.clip = currentClip;
            audioSource.Play();

            Invoke("PlayRandomMusic", currentClip.length);
        }
        else
        {
            Debug.LogWarning("A lista de clipes de áudio está vazia.");
        }
    }

    AudioClip GetRandomClip()
    {
        int randomIndex = Random.Range(0, musicList.Count);
        return musicList[randomIndex];
    }
}
