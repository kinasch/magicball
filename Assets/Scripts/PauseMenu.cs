using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private AudioMixer audioMixer;
    
    private GameObject optionsmenu;
    private static bool GameisPaused = false;
    private Resolution[] resolutions;

    

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        optionsmenu = this.transform.Find("OptionMenu").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.tag != "MainMenu")
        {
            if (!optionsmenu.activeSelf)
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
        Time.timeScale = 1f; // for particle System
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

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
        audioMixer.SetFloat("sfxVolume", volume);
    }
}

