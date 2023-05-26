using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    //Includes all buttons and UI that need to function in every level in the pause menu
    public bool gameRun;
    public GameObject pauseScreen;
    public GameObject restartButton;
    public GameObject exitButton;
    public GameObject quitToMenu;

   
    void Start()
    {
        gameRun = true;
        pauseScreen.SetActive(false);
        restartButton.SetActive(false);
        exitButton.SetActive(false);
        quitToMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameRun == true)
            {
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
                
                gameRun = false;
                pauseScreen.SetActive(true);
                restartButton.SetActive(true);
                exitButton.SetActive(true);
                quitToMenu.SetActive(true);
            }
            else if (gameRun == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1f;
                
                gameRun = true;
                pauseScreen.SetActive(false);
                restartButton.SetActive(false);
                exitButton.SetActive(false);
                quitToMenu.SetActive(false);
            }
        }
    }
}
