using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    private Friction friction;
    private ArmAim armAim;
    private PlayerMovement playerMovement;

    private bool collected=false;
    
    // Start is called before the first frame update
    void Start()
    {
        friction = FindObjectOfType<Friction>();
        armAim = FindObjectOfType<ArmAim>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        if (!collected)
        {
            if (playerMovement.hardMode)
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                this.gameObject.SetActive(true);
            }
        }
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

            collected = true;
            this.gameObject.SetActive(false);
        }
    }
}
