using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private PhysicsMaterial2D ballPhysicsMat;
    private new CircleCollider2D collider;
    private Transform ballTransform;
    private Vector3 ballLocalScale;
    private float formerDrag, bounciness;
    private Friction friction;
    private ArmAim armAimScript;
    
    public bool ballthrown;
    
    void Start()
    {
        armAimScript = FindObjectOfType<ArmAim>();
        friction = FindObjectOfType<Friction>();
        
        ballTransform = transform;
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
        ballLocalScale = transform.localScale;
        ballPhysicsMat = collider.sharedMaterial;
        
        // Trying to have bounciness as value to store things rather than as pointer
        // When leaving out the '0 +' I am not sure whether it's the value that's stored in bounciness
        // or whether it's the reference/pointer to the bounciness in the material, which is bound to change.
        bounciness = 0 + ballPhysicsMat.bounciness;
        formerDrag = 0 + rigidbody.drag;
    }
    
    public void Throw(float launchForce, Transform parent)
    {
        // If the ball is currently child of the arm, the ball can be thrown
        if (ballTransform.parent == parent)
        {
            // Moves the ball up in the hierarchy and makes it able to be influence by gravity and collision
            transform.parent = null;
            collider.isTrigger = false;
            rigidbody.gravityScale = 1;
            // Actual ball movement via initial velocity
            rigidbody.velocity = ballTransform.right * launchForce;
            ballthrown = true;

            armAimScript.enabled = false;
        }
    }

    public void ResetBall(Transform throwPosition, Transform parent)
    {
        friction.glue = false;
        
        // Reset the ball's collider and trigger
        collider.isTrigger = true;
        rigidbody.gravityScale = 0;
        rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0;
        transform.position = throwPosition.position;
        // Also reset the ball's physics
        rigidbody.drag = formerDrag;
        ballPhysicsMat.bounciness = bounciness;

        // Reset the ball's transform
        ballTransform.parent = parent;
        ballTransform.localRotation = Quaternion.identity;
        ballTransform.localScale = ballLocalScale;
        ballTransform.localPosition = throwPosition.localPosition;
        ballthrown = false;
        
        armAimScript.enabled = true;
    }
}
