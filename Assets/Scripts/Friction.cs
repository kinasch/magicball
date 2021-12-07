using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friction : MonoBehaviour
{
    public bool glue;

    private Rigidbody2D ballRigidbody;
    private PhysicsMaterial2D ballPhysicsMaterial;
    
    void Start()
    {
        ballRigidbody = this.GetComponent<Rigidbody2D>();
        ballPhysicsMaterial = this.GetComponent<CircleCollider2D>().sharedMaterial;
    }

    /*
     * Copies the physics material stats from the object the ball is colliding with.
     * This excludes the player.
     */
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (glue)
        {
            ballRigidbody.drag = 100000f;
        }
        // Exclude the player from the copying
        if (!other.gameObject.name.Contains("Player") && !glue)
        {
            var otherPhysicsMaterial2D = other.collider.sharedMaterial;
            // Only take the other material's value if it exists (seems legit lol)
            if (otherPhysicsMaterial2D != null)
            {
                ballPhysicsMaterial.bounciness = otherPhysicsMaterial2D.bounciness;
                ballRigidbody.drag = otherPhysicsMaterial2D.friction;
            }
            else
            {
                ballRigidbody.drag = 0.5f;
                ballPhysicsMaterial.bounciness = 0.5f;
            }
        }
    }
}
