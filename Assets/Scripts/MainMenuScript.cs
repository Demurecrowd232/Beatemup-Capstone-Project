
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//NEEDS TO BE HEAVILY MODIFIED
public class MainMenuScript : MonoBehaviour
{
    public GameObject Canvas;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        
    }

    public void PlayGame()
    {
        Debug.Log("Play Game");
        SceneManager.LoadScene("SetupScene");
    }

    public void Quit()
    {
        Debug.Log("Quit triggered");
        Application.Quit();
    }


}
