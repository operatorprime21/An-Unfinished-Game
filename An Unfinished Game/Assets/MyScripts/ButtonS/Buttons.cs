using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject scenesaver;
    private SceneSave saveScript;
    public GameObject L6skip;
    public GameObject start;
    public GameObject levelOpts;
    public GameObject options;
    public GameObject exit;
    public GameObject back;
    public GameObject credits;
    public GameObject L9End;
    public GameObject continueA;
    public GameObject spoilers;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        L6skip.SetActive(false);
        back.SetActive(false);
        L9End.SetActive(false);
        continueA.SetActive(false);
        spoilers.SetActive(false);
        scenesaver = GameObject.Find("SceneManager");
        saveScript = scenesaver.GetComponent<SceneSave>();
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Begin()
    {
        SceneManager.LoadScene(1);
    }
    public void LevelOptions()
    {
        L6skip.SetActive(true);
        start.SetActive(false);
        levelOpts.SetActive(false);
        options.SetActive(false);
        exit.SetActive(false);
        credits.SetActive(false);
        back.SetActive(true);
        L9End.SetActive(true);
        continueA.SetActive(true);
        spoilers.SetActive(true);
    }
    public void Continue()
    {
        SceneManager.LoadScene(saveScript.quitScene);
    }
    public void L9Final()
    {
        SceneManager.LoadScene(14);
    }
    public void L6Skip()
    {
        SceneManager.LoadScene(7);
    }
    public void Back()
    {
        L6skip.SetActive(false);
        start.SetActive(true);
        levelOpts.SetActive(true);
        options.SetActive(true);
        exit.SetActive(true);
        credits.SetActive(true);
        back.SetActive(false);
        L6skip.SetActive(false);
        back.SetActive(false);
        L9End.SetActive(false);
        continueA.SetActive(false);
        spoilers.SetActive(false);
    }
}
