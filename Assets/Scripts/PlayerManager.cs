using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health , bulletSpeed;

    bool dead = false;

    Transform muzzle;
    
    public Transform bullet,floatingText,bloodParticle;

    public Slider slider;

    bool mouseIsNotOverUI;

    void Start()
    {
        //NAMLUNUN NEREDE OLDUÐUNU KONTROL EDÝYOR
        muzzle = transform.GetChild(1);

        //CAN BARLARINI TANIMLIYOR
        slider.maxValue = health;
        slider.value = health;
    }

    void Update()
    {
        //BUTONLARA TIKLADIÐIMIZDA MERMÝ ATMASINI ENGELLÝYOR
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;

        //MERMÝLERÝ HANGÝ TUÞA BAÞARAK ATACAÐIMIZI KONTROL EDÝYOR
        if (Input.GetMouseButtonDown(0) && mouseIsNotOverUI)
        {
            ShootBullet();
        }
    }

    public void GetDamage(float damage)
    {
        //KARAKTER HASAR ALDIÐINDA NE KADAR HASAR ALDIÐINI YAZIYOR
        Instantiate(floatingText, transform.position, Quaternion.identity)
                     .GetComponent<TextMesh>().text = damage.ToString();

        //KARAKTER HASAR ALIRSA NE YAPICAÐINI KONTROL EDÝYOR
        if ((health- damage) >=0)
        {
            health -= damage;
        }else
        {
            health = 0;
        }
        slider.value = health;
        AmIDead();
    }

    //KARAKTERÝN TAMAMEN ÖLÜP ÖLMEDÝÐÝNÝ KONTROL EDÝYOR
    void AmIDead()
    {
        if(health <= 0)
        {
            //KAN EFEKTÝNÝ OLUÞTURUP BELÝRLENEN SÜRE SONRA YOK EDÝYOR 
            Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity), 3f);

            //OYUNUN KAYBEDÝLDÝÐÝNÝ BELÝRTÝYOR
            DataManager.Instance.LoseProcess();

            //PLAYERIN ÖLDÜÐÜNÜ BELÝRTÝYOR VE YOK EDÝYOR
            dead = true;
            Destroy(gameObject);
        }
    }

    void ShootBullet()
    {
        //MERMÝLERÝ OLUÞTURUP ATEÞLEMEMÝZÝ KONTROL EDÝYOR
        Transform tempBullet;
        tempBullet = Instantiate (bullet,muzzle.position,Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);

        //HER MERMÝ ATILDIÐINDA SAYIOYOR
        DataManager.Instance.ShotBullet++;
    }
}
