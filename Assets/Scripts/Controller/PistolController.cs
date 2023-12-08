using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PistolController : MonoBehaviour
{
    private PistolModel __pistolModel;
    private Animator __animator;
    //last shot time
    private float __lastShotTime = 0f;
    private float __lastReloadTime = 0f;
    private int __currentBullets = 0;
    private BulletUI __bulletUI;
    private Image __reloadUI;

    // Start is called before the first frame update
    void Start()
    {
        __pistolModel = GetComponent<PistolModel>();
        __currentBullets = __pistolModel.Bullets;
        __animator = GetComponent<Animator>();
        __bulletUI = GameObject.Find("NumberAmmo").GetComponent<BulletUI>();
        __reloadUI = GameObject.Find("Reload").GetComponent<Image>();

        __reloadUI.color = new Color(1, 1, 1, 0.3f);
        __bulletUI.UpdateBulletUI(__pistolModel.Bullets + 1); // Atualiza a UI de balas
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // Verifica se o botão esquerdo do mouse foi pressionado
        {
            Shot(); // Chama a função para clonar o objeto
        }
    }

    void Shot()
    {
        __bulletUI.UpdateBulletUI(__currentBullets); // Atualiza a UI de balas
        if (Time.time - __lastShotTime < __pistolModel.FireRate) // Verifica se o tempo entre o último tiro e o atual é menor que o tempo de recarga
        {
            AudioSource.PlayClipAtPoint(__pistolModel.ReloadSound, transform.position); // Caso seja, toca o som de recarga
            return; // Caso seja, retorna e não executa o tiro
        }

        if (__currentBullets <= 0)
        {
            if (Time.time - __lastReloadTime < __pistolModel.ReloadTime)
            {
                StartCoroutine(Reload(__pistolModel.ReloadTime));
                AudioSource.PlayClipAtPoint(__pistolModel.ReloadSound, transform.position); // Caso seja, toca o som de recarga
                return; // Caso seja, retorna e não executa o tiro
            }
            else
            {
                __bulletUI.UpdateBulletUI(__currentBullets + 1); // Atualiza a UI de balas
                __currentBullets = __pistolModel.Bullets;
                __lastReloadTime = Time.time;
            }
        }

        __animator.SetBool("isShooting", true);
        //ShotSound play
        AudioSource.PlayClipAtPoint(__pistolModel.ShotSound, transform.position);

        GameObject bullet = Instantiate(__pistolModel.Bullet);
        bullet.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z); // Define a posição do objeto clonado

        __currentBullets--; // Diminui a quantidade de balas
        __lastShotTime = Time.time;

        // set interval 0.6s to stop animation
        Invoke("StopAnimation", 0.3f);
    }

    IEnumerator Reload(float time)
    {
        __reloadUI.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(time);
        __reloadUI.color = new Color(1, 1, 1, 0.3f);

        __bulletUI.UpdateBulletUI(__currentBullets); // Atualiza a UI de balas
    }

    void StopAnimation()
    {
        __animator.SetBool("isShooting", false);
    }

}
