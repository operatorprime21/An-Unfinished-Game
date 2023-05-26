using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSave : MonoBehaviour
{
    public int deadScene;
    public int quitScene;
    //Originally only one int was supposed to handle the semi-save function that the player can use to retry the level they just exitted or die from. BUT
    //FOR SOME REASON more than one if statement does NOT work with buildIndex if you try to manipulate ONE int. Using else if or (A || B) DOES NOT work and breaks the int value for EITHER situation
    //The workaround solution was to make 2 ints separately. 
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 20)
        {
           deadScene = SceneManager.GetActiveScene().buildIndex;
        }
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
           quitScene = SceneManager.GetActiveScene().buildIndex;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    
}
