using UnityEngine;

[CreateAssetMenu(fileName = "NewDialog", menuName = "Objects/New Dialog")]
public class Frame : ScriptableObject
{
    public string text;
    public Sprite image;
    public float duration = 10f;
}
