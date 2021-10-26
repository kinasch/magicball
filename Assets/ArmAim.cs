using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAim : MonoBehaviour
{
    //script to makes arms look to mouse position
    void FixedUpdate()
    {
        Vector2 armPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Camera.main.ScreenToWorldPoint transforms pixel coordinates to world space 
        Vector2 direction = mousePosition - armPosition;
        transform.right = direction;
    }
}
