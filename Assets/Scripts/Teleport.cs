using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject magicBall;
    public GameObject arm;
    public ThrowBall throwBall;
    // Determines at what x-velocity of the ball the player should teleport
    public float teleportX = 0.05f;

    private ArmAim armAimScript;

    private void Start()
    {
        armAimScript = arm.GetComponent<ArmAim>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (magicBall.transform.parent == null)
        {
            Vector3 magicBallVelocity = magicBall.GetComponent<Rigidbody2D>().velocity;
            // Check if velocity is nearly zero
            if (Math.Abs(magicBallVelocity.x) <= teleportX && Math.Abs(magicBallVelocity.y) == 0)
            {
                TeleportPlayer();
                throwBall.ResetBall(armAimScript.throwPosition, arm.transform);
            }
        }
    }

    void TeleportPlayer()
    {
        this.transform.position = magicBall.transform.position;
    }
}
