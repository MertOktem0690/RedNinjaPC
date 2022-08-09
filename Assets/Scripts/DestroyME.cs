using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyME : MonoBehaviour
{
    public int lifeTime;

    void Start()
    {
        //BELÝRLENEN OBJENÝN BELÝRLENEN SÜREDE YOK OLMASINI KONTROL EDÝYOR
        Destroy(gameObject, lifeTime);
    }
}
