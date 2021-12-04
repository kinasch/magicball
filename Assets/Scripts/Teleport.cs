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
    public float teleportX = 0.2f; //ball velocity when player teleports to ball 

    private ArmAim armAimScript;
    
    public Animator animator;

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
            animator.ResetTrigger("Teleport");
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
        animator.SetTrigger("Teleport");
    }

    // I need a way to reset some things that would be lost if the game is quit e.g. during the ball's flying phase
    private void OnApplicationQuit()
    {
        throwBall.ResetBall(armAimScript.throwPosition, arm.transform);
    }
}
