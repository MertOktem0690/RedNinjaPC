using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float bulletDamage, lifeTime;

    void Start()
    {
        //MERMÝYÝ BELÝRLENEN SÜREDE YOK EDÝYOR
        Destroy(gameObject, lifeTime);
    }
}
