using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    private Friction friction;
    private ArmAim armAim;
    
    // Start is called before the first frame update
    void Start()
    {
        friction = FindObjectOfType<Friction>();
        armAim = FindObjectOfType<ArmAim>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            if (this.gameObject.name.Contains("Glue"))
            {
                friction.glue = true;
            }
            else if (this.gameObject.name.Contains("Trajectory"))
            {
                armAim.trajectoryUpgrade = true;
            }
            this.gameObject.SetActive(false);
        }
    }
}
