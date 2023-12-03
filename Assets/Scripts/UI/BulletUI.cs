using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletUI : MonoBehaviour
{
    public Sprite[] numbers;
    public Sprite no_ammo;

    private Image __image;

    public void UpdateBulletUI(int bullets)
    {
        __image = GetComponent<Image>();
        if (bullets > 0 && bullets < 9)
        {
            __image.sprite = numbers[bullets - 1];
        }
        else
        {
            __image.sprite = no_ammo;
        }
    }
}
