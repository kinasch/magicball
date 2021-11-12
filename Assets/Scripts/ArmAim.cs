using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAim : MonoBehaviour
{
    public GameObject magicBall;
    public float launchForce;
    public Transform throwPosition;

    //script to makes arms look to mouse position
    void Update()
    {
        Vector2 armPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Camera.main.ScreenToWorldPoint transforms pixel coordinates to world space 
        Vector2 direction = mousePosition - armPosition;
        transform.right = direction;

        if (Input.GetMouseButton(0))
        {
            launchForce += 0.01f;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Throw();
            launchForce = 6;
        }
    }
    void Throw() 
    {
        GameObject newMagicball = Instantiate(magicBall, throwPosition.position, throwPosition.rotation);
        newMagicball.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }
}
