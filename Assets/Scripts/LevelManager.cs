using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject section1Layout;
    public GameObject section2Layout;
    public GameObject section3Layout;
    public GameObject canvas;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject healthBar;
    public GameObject bossHealthBar;
    public bool canPause;
    public int levelNum = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            //isPaused = !isPaused;
            Pause();
        }
    }

    public void Pause()
    {
        canPause = !canPause;
        if(canPause)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            healthBar.SetActive(false);
            bossHealthBar.SetActive(false);
        }
        else if (!canPause)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            healthBar.SetActive(true);
            bossHealthBar.SetActive(true);
        }
    }


    public void Continue()
    {
            if(levelNum == 0)
            {
                section1Layout.SetActive(false);
                section2Layout.SetActive(true);
                levelNum += 1;
                return;
            }

            if (levelNum == 1)
            {

                section2Layout.SetActive(false);
                section3Layout.SetActive(true);
                levelNum += 1 ;
                return;
            }

            if (levelNum == 2)
            {
            //End Game/ Win Scene
            Debug.Log("END GAME WIN");
            SceneManager.LoadScene("WinGameScene");
            }
        
    }

    public void PlayerIsDead()
    {
        //Lose Screen/Restart
        Debug.Log("Player Died");
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameOverMenu.SetActive(true);
        healthBar.SetActive(false);
        bossHealthBar.SetActive(false);

    }
    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("Level-1");
    }
}
