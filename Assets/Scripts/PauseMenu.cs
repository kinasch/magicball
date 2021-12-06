using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Menu;
    public static bool GameisPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        // if(this.tag != "MainMenu")
        // {
        //     Menu.SetActive(false);
        // }     
    }

    // Update is called once per frame
    void Update()
    {
        if (this.tag != "MainMenu")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameisPaused)
                {
                    Return();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void Return()
    {
        Menu.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    public void Pause()
    {
        Debug.Log("Game is paused");
        Menu.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Menu.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    public void Options()
    {
        Debug.Log("shows options");
    }

    public void Level()
    {
        Debug.Log("shows levels");
    }

    public void Exit()
    {
        Debug.Log("exits to main menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void ContinueGame()
    {
        Debug.Log("continue game");
        SceneManager.LoadScene("FirstLevelScene");
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    public void EndGame()
    {
        Debug.Log("end game");
        Application.Quit();
    }
}

