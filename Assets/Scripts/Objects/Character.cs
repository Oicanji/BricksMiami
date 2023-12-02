using UnityEngine;

[CreateAssetMenu(fileName = "NewChar", menuName = "Objects/New Character")]
public class Character : ScriptableObject
{

    public string id;
    public Sprite walk;
    public Sprite idle;
    public Sprite profileMax;
    public Sprite profileMed;
    public Sprite profileMin;
    public Sprite uiName;
    public AnimationClip meeleAttack;
    public float speed;
    public float dashSpeed;
    public float dashCooldown = 4f;
    public float life;
    public float doubleTapTimeThreshold = 0.5f;
    public float invunerableTime = 10f;
    public float meeleCountdown = 10f;
    public Vector2 direction;
    public AudioClip hitEffect;
    public AudioClip invunerableEffect;
}
