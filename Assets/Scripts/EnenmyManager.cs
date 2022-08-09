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
        //KARAKTER, DÜÞMANA DOKUNUNCA NE OLACAÐINI KONTROL EDÝYOR
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerManager>().GetDamage(damage);
        }
        //MERMÝ, DÜÞMANA DOKNUNCA NE OLACAÐINI KONTROL EDÝYOR
        else if (other.tag == "Bullet")
        {
            GetDamage(other.GetComponent<BulletManager>().bulletDamage);
            Destroy(other.gameObject);
        }

        //print("Collider alanýna girdi: " + other.name);
    }

    //KARAKTER ÝÇÝNDEYKEN NAPICAÐINI KONTROL EDÝYOR
    private void OnTriggerStay2D(Collider2D other)
    {
        //print("Collider alanýnda bulunuyor: " + other.name);
    }

    //KARAKTER DOKUNMAYI BÝTÝRDÝÐÝNDE NAPICAÐINI KONTROL EDÝYOR
    private void OnTriggerExit2D(Collider2D other)
    {
        //print("Collider alanýndan çýktý: " + other.name);
    }

    //DÜÞMAN HASAR ALIRSA NE YAPICAÐINI KONTROL EDÝYOR
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
            //DÜÞMAN ÖLDÜÐÜNDE SAYIYOR
            DataManager.Instance.EnemyKilled++;

            //DÜÞMANI YOK EDÝYOR
            Destroy(gameObject);
        }
    }
}
