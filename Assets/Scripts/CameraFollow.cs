using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform ballTransform;
    [SerializeField] private ThrowBall bt;
    private float cameraZ = -150f;
    
    

    void Update()
    {
        if (bt.ballthrown)
        {
            transform.position = new Vector3(ballTransform.position.x, ballTransform.position.y, cameraZ);
           
        }
        else
        {
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, cameraZ);
        }
        
    }
}
