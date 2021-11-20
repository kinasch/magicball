using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveX;
    public float moveSpeed = 12f;
    public Animator animator;

    void Update()

    {
        animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));

        moveX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(moveX, 0, 0) * Time.deltaTime * moveSpeed;
    }
}
