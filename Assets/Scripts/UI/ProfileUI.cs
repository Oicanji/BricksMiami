using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileUI : MonoBehaviour
{
    [SerializeField] private Sprite profileMax;
    [SerializeField] private Sprite profileMed;
    [SerializeField] private Sprite profileMin;

    public Sprite ProfileMax
    {
        get { return profileMax; }
        set { profileMax = value; }
    }
    public Sprite ProfileMed
    {
        get { return profileMed; }
        set { profileMed = value; }
    }
    public Sprite ProfileMin
    {
        get { return profileMin; }
        set { profileMin = value; }
    }

    public void UpdateProfile(float life, float max_life)
    {
        print(life * 100 / max_life);
        if (life * 100 / max_life > 70.0f)
        {
            GetComponent<Image>().sprite = profileMax;
        }
        else if (life / max_life > 30.0f)
        {
            GetComponent<Image>().sprite = profileMed;
        }
        else
        {
            GetComponent<Image>().sprite = profileMin;
        }
    }
}
