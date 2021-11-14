using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private new CircleCollider2D collider;
    private Transform ballTransform;
    private Vector3 ballLocalScale;
    
    void Start()
    {
        ballTransform = this.transform;
        rigidbody = this.GetComponent<Rigidbody2D>();
        collider = this.GetComponent<CircleCollider2D>();
        ballLocalScale = this.transform.localScale;
    }
    
    public void Throw(float launchForce, Transform parent)
    {
        // If the ball is currently child of the arm, the ball can be thrown
        if (ballTransform.parent == parent)
        {
            // Moves the ball up in the hierarchy and makes it able to be influence by gravity and collision
            this.transform.parent = null;
            collider.isTrigger = false;
            rigidbody.gravityScale = 1;
            // Actual ball movement via initial velocity
            rigidbody.velocity = ballTransform.right * launchForce;
        }
    }

    public void ResetBall(Transform throwPosition, Transform parent)
    {
        // Reset the ball's collider and trigger
        collider.isTrigger = true;
        rigidbody.gravityScale = 0;
        rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0;
        this.transform.position = throwPosition.position;

        // Reset the ball's transform
        ballTransform.parent = parent;
        ballTransform.localRotation = Quaternion.identity;
        ballTransform.localScale = ballLocalScale;
        ballTransform.localPosition = throwPosition.localPosition;
    }
}
