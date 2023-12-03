using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WarningUI : MonoBehaviour
{
    private Image backgroundImage;
    private TextMeshProUGUI text;
    private Color color;
    public AudioClip alertSound;
    // Start is called before the first frame update
    void Start()
    {
        backgroundImage = GameObject.Find("AlertBackground").GetComponent<Image>();
        text = GameObject.Find("AlertText").GetComponent<TextMeshProUGUI>();
        color = backgroundImage.color;
        backgroundImage.color = new Color(color.r, color.g, color.b, 0);
        text.color = new Color(1, 1, 1, 0);
        //fade in 
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(1f);
        AudioSource.PlayClipAtPoint(alertSound, transform.position);
        for (float i = 0; i <= 1; i += 0.05f)
        {
            backgroundImage.color = new Color(color.r, color.g, color.b, i);
            text.color = new Color(1, 1, 1, i);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(4f);
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut()
    {
        for (float i = 1; i >= 0; i -= 0.05f)
        {
            backgroundImage.color = new Color(color.r, color.g, color.b, i);
            text.color = new Color(1, 1, 1, i);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("title_screen");
    }

    // Update is called once per frame
    void Update()
    {
        // if enter or space is pressed, skip the warning
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("title_screen");
        }
    }
}
