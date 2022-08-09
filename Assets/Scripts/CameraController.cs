using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;

    public float cameraSpeed;

    void Update()
    {
        //YUMUÞAK HAREKETLERLE "SLERP" KAMERA TAKÝP
        transform.position = Vector3.Slerp(transform.position, new Vector2(Player.position.x, 0f), cameraSpeed);
    }
}
