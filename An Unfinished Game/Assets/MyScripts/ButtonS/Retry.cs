using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Retry : MonoBehaviour
{
    public GameObject scenesaver;
    private SceneSave saveScript;
 
    void Start()
    {
        scenesaver = GameObject.Find("SceneManager");
        saveScript = scenesaver.GetComponent<SceneSave>();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void TaskOnClick()
    {
        SceneManager.LoadScene(saveScript.deadScene);
    }
}
