using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ArmAim : MonoBehaviour
{
    public float launchForce;
    public Transform throwPosition;
    public GameObject magicBall;

    private ThrowBall throwBall;

    private void Start()
    {
        throwBall = magicBall.GetComponent<ThrowBall>();
    }

    //script to makes arms look to mouse position
    void Update()
    {
        Vector2 armPosition = transform.position;
        //Camera.main.ScreenToWorldPoint transforms pixel coordinates to world space 
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - armPosition;
        transform.right = direction;

        if (magicBall.transform.parent == this.transform && magicBall.transform.position != throwPosition.position)
        {
            magicBall.transform.position = throwPosition.position;
        }

        if (Input.GetMouseButton(0))
        {
            launchForce += Time.deltaTime;
            Debug.Log(launchForce);
        }

        if (Input.GetMouseButtonUp(0))
        {
            throwBall.Throw(launchForce, this.transform);
            launchForce = 6;
        }
    }
}