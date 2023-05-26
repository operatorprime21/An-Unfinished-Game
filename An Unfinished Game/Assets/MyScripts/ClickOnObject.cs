using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnObject : MonoBehaviour
{
    bool onScreen = false;
    public GameObject note;
    public Transform player;
    
    // The script that handles all texts and notes found in each level. Click on paper to read, esc to leave
    void Start()
    {
        note.SetActive(false);
    }
    void OnMouseDown()
    {
        if (onScreen == false && Vector3.Distance(player.position, transform.position) <= 5f)
        {
            onScreen = true;
            note.SetActive(true);
            Debug.Log("1");
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && onScreen == true)
        {
            onScreen = false;
            Debug.Log("2");
            note.SetActive(false);
        }
    }
}
