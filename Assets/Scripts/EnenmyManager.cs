using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnenmyManager : MonoBehaviour
{
    public float damage,health;

    public Slider slider;

    void Start()
    {
        //CAN BARLARINI TANIMLIYOR
        slider.maxValue = health;
        slider.value = health;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //KARAKTER, D��MANA DOKUNUNCA NE OLACA�INI KONTROL ED�YOR
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerManager>().GetDamage(damage);
        }
        //MERM�, D��MANA DOKNUNCA NE OLACA�INI KONTROL ED�YOR
        else if (other.tag == "Bullet")
        {
            GetDamage(other.GetComponent<BulletManager>().bulletDamage);
            Destroy(other.gameObject);
        }

        //print("Collider alan�na girdi: " + other.name);
    }

    //KARAKTER ���NDEYKEN NAPICA�INI KONTROL ED�YOR
    private void OnTriggerStay2D(Collider2D other)
    {
        //print("Collider alan�nda bulunuyor: " + other.name);
    }

    //KARAKTER DOKUNMAYI B�T�RD���NDE NAPICA�INI KONTROL ED�YOR
    private void OnTriggerExit2D(Collider2D other)
    {
        //print("Collider alan�ndan ��kt�: " + other.name);
    }

    //D��MAN HASAR ALIRSA NE YAPICA�INI KONTROL ED�YOR
    public void GetDamage(float damage)
    {
        if ((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        AmIDead();
    }

    void AmIDead()
    {
        if (health <= 0)
        {
            //D��MAN �LD���NDE SAYIYOR
            DataManager.Instance.EnemyKilled++;

            //D��MANI YOK ED�YOR
            Destroy(gameObject);
        }
    }
}
