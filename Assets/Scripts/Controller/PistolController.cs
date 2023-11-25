using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : MonoBehaviour
{
    private PistolModel __pistolModel;
    //last shot time
    private float __lastShotTime = 0f;
    private float __lastReloadTime = 0f;
    private int __currentBullets = 0;

    // Start is called before the first frame update
    void Start()
    {
        __pistolModel = GetComponent<PistolModel>();
        __currentBullets = __pistolModel.Bullets;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Verifica se a tecla de espaço foi pressionada
        {
            Shot(); // Chama a função para clonar o objeto
        }
    }

    void Shot()
    {

        if (Time.time - __lastShotTime < __pistolModel.FireRate) // Verifica se o tempo entre o último tiro e o atual é menor que o tempo de recarga
        {
            print("Aguarde o tempo de recarga");
            AudioSource.PlayClipAtPoint(__pistolModel.ReloadSound, transform.position); // Caso seja, toca o som de recarga
            return; // Caso seja, retorna e não executa o tiro
        }

        if (__currentBullets <= 0)
        {
            if (Time.time - __lastReloadTime < __pistolModel.ReloadTime)
            {
                print("Aguarde o tempo de recarga");
                AudioSource.PlayClipAtPoint(__pistolModel.ReloadSound, transform.position); // Caso seja, toca o som de recarga
                return; // Caso seja, retorna e não executa o tiro
            }
            else
            {
                __currentBullets = __pistolModel.Bullets;
                __lastReloadTime = Time.time;
            }
        }

        //ShotSound play
        AudioSource.PlayClipAtPoint(__pistolModel.ShotSound, transform.position);

        GameObject bullet = Instantiate(__pistolModel.Bullet);
        bullet.transform.position = new Vector3(transform.position.x, transform.position.y + __pistolModel.DistanceSpawnY, transform.position.z); // Define a posição do objeto clonado

        __currentBullets--; // Diminui a quantidade de balas
        __lastShotTime = Time.time;
    }

}
