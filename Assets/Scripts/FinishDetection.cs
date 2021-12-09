using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDetection : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    private PauseMenu pauseMenu;
    private Timer timer;

    private void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
        timer = gameManager.GetComponent<Timer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            timer.StopTimer();
            pauseMenu.Exit();
        }
    }
}
