using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float bulletDamage, lifeTime;

    void Start()
    {
        //MERM�Y� BEL�RLENEN S�REDE YOK ED�YOR
        Destroy(gameObject, lifeTime);
    }
}
