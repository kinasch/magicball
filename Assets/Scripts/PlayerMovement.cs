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
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        moveX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(moveX, 0, 0) * Time.deltaTime * moveSpeed;
    }
}
