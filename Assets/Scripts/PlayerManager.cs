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
        //NAMLUNUN NEREDE OLDU�UNU KONTROL ED�YOR
        muzzle = transform.GetChild(1);

        //CAN BARLARINI TANIMLIYOR
        slider.maxValue = health;
        slider.value = health;
    }

    void Update()
    {
        //BUTONLARA TIKLADI�IMIZDA MERM� ATMASINI ENGELL�YOR
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;

        //MERM�LER� HANG� TU�A BA�ARAK ATACA�IMIZI KONTROL ED�YOR
        if (Input.GetMouseButtonDown(0) && mouseIsNotOverUI)
        {
            ShootBullet();
        }
    }

    public void GetDamage(float damage)
    {
        //KARAKTER HASAR ALDI�INDA NE KADAR HASAR ALDI�INI YAZIYOR
        Instantiate(floatingText, transform.position, Quaternion.identity)
                     .GetComponent<TextMesh>().text = damage.ToString();

        //KARAKTER HASAR ALIRSA NE YAPICA�INI KONTROL ED�YOR
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

    //KARAKTER�N TAMAMEN �L�P �LMED���N� KONTROL ED�YOR
    void AmIDead()
    {
        if(health <= 0)
        {
            //KAN EFEKT�N� OLU�TURUP BEL�RLENEN S�RE SONRA YOK ED�YOR 
            Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity), 3f);

            //OYUNUN KAYBED�LD���N� BEL�RT�YOR
            DataManager.Instance.LoseProcess();

            //PLAYERIN �LD���N� BEL�RT�YOR VE YOK ED�YOR
            dead = true;
            Destroy(gameObject);
        }
    }

    void ShootBullet()
    {
        //MERM�LER� OLU�TURUP ATE�LEMEM�Z� KONTROL ED�YOR
        Transform tempBullet;
        tempBullet = Instantiate (bullet,muzzle.position,Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);

        //HER MERM� ATILDI�INDA SAYIOYOR
        DataManager.Instance.ShotBullet++;
    }
}
