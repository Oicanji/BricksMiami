using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HistoryController : MonoBehaviour
{
    public Frame[] frames;
    public int currentFrame = 0;
    public string nextScene;

    private Image __image;
    private TextMeshProUGUI __text;

    // Start is called before the first frame update
    void Start()
    {
        __image = GameObject.Find("Image").GetComponent<Image>();
        __text = GameObject.Find("Text").GetComponentInChildren<TextMeshProUGUI>();

        __image.sprite = frames[currentFrame].image;
        __text.text = frames[currentFrame].text;

        StartCoroutine(NextFrame(frames[currentFrame].duration));
    }

    // Update is called once per frame
    void Update()
    {
        // if press space skip actual frame
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            currentFrame++;
            if (currentFrame < frames.Length)
            {
                __image.sprite = frames[currentFrame].image;
                __text.text = frames[currentFrame].text;
                StartCoroutine(NextFrame(frames[currentFrame].duration));
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
            }
        }
        // press enter or esc skip all frames
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
        }
    }

    IEnumerator NextFrame(float duration)
    {
        yield return new WaitForSeconds(duration);
        currentFrame++;
        print(currentFrame);
        print(frames.Length);
        if (currentFrame < frames.Length)
        {
            __image.sprite = frames[currentFrame].image;
            __text.text = frames[currentFrame].text;
            StartCoroutine(NextFrame(frames[currentFrame].duration));
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
        }
    }
}
