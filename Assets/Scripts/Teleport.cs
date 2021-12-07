using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject magicBall;
    public GameObject arm;
    public ThrowBall throwBall;
    // Determines at what x-velocity of the ball the player should teleport
    public float teleportX = 0.2f; //ball velocity when player teleports to ball 

    private ArmAim armAimScript;
    private Friction friction;
    private bool isGoingToTeleport = false;

    public Animator animator;

    private void Start()
    {
        armAimScript = arm.GetComponent<ArmAim>();
        friction = FindObjectOfType<Friction>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (magicBall.transform.parent == null)
        {
            Vector3 magicBallVelocity = magicBall.GetComponent<Rigidbody2D>().velocity;
            // Check if velocity is nearly zero
            animator.ResetTrigger("Teleport");
            if (Math.Abs(magicBallVelocity.x) <= teleportX + 0.005f && Math.Abs(magicBallVelocity.x) >= teleportX && Math.Abs(magicBallVelocity.y) <= teleportX)
            {
                animator.SetBool("readyTeleport", true);
            }

            if (Math.Abs(magicBallVelocity.x) <= teleportX && (Math.Abs(magicBallVelocity.y) == 0 || (friction.glue && magicBall.GetComponent<Rigidbody2D>().drag >= 1000f)))
            {
                if (!isGoingToTeleport)
                {   
                    isGoingToTeleport = true;
                    StartCoroutine(TeleportPlayer());
                }
                
            }
        }
    }

    IEnumerator TeleportPlayer()
    {
        if (friction.glue)
        {
            yield return new WaitForSeconds(1.5f);
            animator.SetBool("readyTeleport", true);
            yield return new WaitForSeconds(0.5f);
            
        }
        this.transform.position = magicBall.transform.position;
        throwBall.ResetBall(armAimScript.throwPosition, arm.transform);
        animator.SetBool("readyTeleport", false);
        animator.SetTrigger("Teleport");
        isGoingToTeleport = false;
        yield return null;
    }

    // I need a way to reset some things that would be lost if the game is quit e.g. during the ball's flying phase
    private void OnApplicationQuit()
    {
        throwBall.ResetBall(armAimScript.throwPosition, arm.transform);
    }
}
