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
    

    void FixedUpdate()

    {
        if (playerRB.velocity.y >= 0)
        {
            animator.SetBool("Falling", false);
            moveX = Input.GetAxisRaw("Horizontal");
            animator.SetFloat("Horizontal", moveX);

            playerRB.velocity = new Vector2(moveX * moveSpeed, 0);

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
            animator.SetBool("Falling", true);
            playerRB.velocity = new Vector2((moveX/2)*moveSpeed, Mathf.Clamp(playerRB.velocity.y, playerYVelocityMax, 0));
        }

        
        
 
    }

    private void Start()
    {
        playerRB = this.GetComponent<Rigidbody2D>();
    }
}
