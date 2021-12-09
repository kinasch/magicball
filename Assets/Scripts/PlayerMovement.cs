using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveX;
    private Rigidbody2D playerRB;
    private float playerYVelocityMax = -10;
    public float moveSpeed = 12f;
    public Animator animator;

    private bool isHeld = false;

    public bool hardMode=false;
    

    void FixedUpdate()

    {
        if (playerRB.velocity.y >= 0)
        {
            animator.SetBool("Falling", false);
            if (!hardMode)
            {
                moveX = Input.GetAxisRaw("Horizontal");
                animator.SetFloat("Horizontal", moveX);

                playerRB.velocity = new Vector2(moveX * moveSpeed, 0);
            }

            if (Input.GetMouseButton(0) && !isHeld)
            {
                isHeld = true;
                animator.ResetTrigger("Firing");
                animator.SetBool("isCharging", true);
            }
            
            else if (Input.GetMouseButton(0) && isHeld)
            {
                animator.SetBool("isCharging", true);
            }

            else if (isHeld)
            {
                isHeld = false;
                animator.SetBool("isCharging", false);
                animator.SetTrigger("Firing");
            }
        }
        else
        {
            if(playerRB.velocity.y <= -1f){
                animator.SetBool("Falling", true);
            }
            playerRB.velocity = new Vector2(playerRB.velocity.x, Mathf.Clamp(playerRB.velocity.y, playerYVelocityMax, 0));
        }

        
        
 
    }

    public void changeHardMode()
    {
        hardMode = !hardMode;
    }

    private void Start()
    {
        playerRB = this.GetComponent<Rigidbody2D>();
    }
}
