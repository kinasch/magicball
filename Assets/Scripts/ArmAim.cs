using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ArmAim : MonoBehaviour
{
    
    [SerializeField] public Transform throwPosition;
    [SerializeField] private GameObject magicBall;
    [SerializeField] private float maxLaunchForce;
    private float launchForce;

    private ThrowBall throwBall;
    private Vector2 direction;
    
    [Header("Trajectory")]
    [SerializeField] private GameObject pointForTrajectory;
    [SerializeField] private int numberOfPoints;
    [SerializeField] private float spaceBetweenPoints;
    private GameObject[] points;

    public bool trajectoryUpgrade;

    private void Start()
    {
        throwBall = magicBall.GetComponent<ThrowBall>();

        points = new GameObject[numberOfPoints];
        for (var i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(pointForTrajectory,throwPosition);
            points[i].SetActive(false);
        }
    }

    //script to makes arms look to mouse position
    void Update()
    {
        Vector2 armPosition = transform.position;
        //Camera.main.ScreenToWorldPoint transforms pixel coordinates to world space 
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - armPosition;
        transform.right = direction;

        if (magicBall.transform.parent == this.transform && magicBall.transform.position != throwPosition.position)
        {
            magicBall.transform.position = throwPosition.position;
        }

        if (points[0].activeSelf)
        {
            for (var i = 0; i < numberOfPoints; i++)
            {
                points[i].SetActive(false);
            }
        }
        if (trajectoryUpgrade)
        {
            if (!points[0].activeSelf)
            {
                for (var i = 0; i < numberOfPoints; i++)
                {
                    points[i].SetActive(true);
                }
            }
            for (var i = 0; i < numberOfPoints; i++)
            {
                points[i].transform.position = SetTrajectoryPoint(i*spaceBetweenPoints);
            }
        }

        if (Input.GetMouseButton(0))
        {
            launchForce += Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0))
        {
            throwBall.Throw(Mathf.Clamp(launchForce,6,maxLaunchForce), this.transform);
            launchForce = 6;
        }
    }

    /// <summary>
    /// Draws the trajectory the ball would be flying with the current aim and launchForce.
    /// </summary>
    private Vector2 SetTrajectoryPoint(float t)
    {
        var position = (Vector2)throwPosition.position + (direction.normalized * Mathf.Clamp(launchForce,6,maxLaunchForce) * t) +
                       0.5f * Physics2D.gravity * Mathf.Pow(t, 2);
        return position;
    }
}