using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Rendering;

public class MiniMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject SettingsHolder;
    public GameObject miniMenu;
  

    private void Start()
    {
        
        Resume();
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                ActiveObject();
                Resume();
              
                if (miniMenu.activeInHierarchy == true || SettingsHolder.activeInHierarchy==true)
                {
                    miniMenu.SetActive(false);
                    SettingsHolder.SetActive(false);
                }
            }
            else
            {
                ActiveObject();
                Pause();
            }

        }
           
    }
    public void ActiveObject()
    {
        if (pauseMenuUI.activeSelf != true)
        {
            pauseMenuUI.SetActive(true);

        }
        else
        {
            SettingsHolder.SetActive(false);
            pauseMenuUI.SetActive(false);
            miniMenu.SetActive(true);
        }
    }
    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    void Pause()
    {
       pauseMenuUI.SetActive(true);
       // Time.timeScale = 0.0f;
        gameIsPaused = true;
    }
}
