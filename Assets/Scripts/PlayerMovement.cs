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
    
    

    void FixedUpdate()

    {
        if (playerRB.velocity.y >= 0)
        {
            animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));

            moveX = Input.GetAxisRaw("Horizontal");
            playerRB.velocity = new Vector2(moveX * moveSpeed, 0);
        }
        else
        {
            playerRB.velocity = new Vector2((moveX/2)*moveSpeed, Mathf.Clamp(playerRB.velocity.y, playerYVelocityMax, 0));
        }
    }

    private void Start()
    {
        playerRB = this.GetComponent<Rigidbody2D>();
    }
}
