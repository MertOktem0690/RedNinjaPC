using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyME : MonoBehaviour
{
    public int lifeTime;

    void Start()
    {
        //BEL�RLENEN OBJEN�N BEL�RLENEN S�REDE YOK OLMASINI KONTROL ED�YOR
        Destroy(gameObject, lifeTime);
    }
}
