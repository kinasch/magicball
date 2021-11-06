using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public float cameraZoom = -100f;


    void FixedUpdate()
    {
        this.transform.position = new Vector3(Player.position.x, Player.position.y, cameraZoom);


    }
}
