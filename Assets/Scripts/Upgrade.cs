using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    private Friction friction;
    
    // Start is called before the first frame update
    void Start()
    {
        friction = FindObjectOfType<Friction>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            friction.glue = true;
            this.gameObject.SetActive(false);
        }
    }
}
