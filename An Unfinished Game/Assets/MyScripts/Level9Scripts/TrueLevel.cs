using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrueLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //The script that decides what ending the player receives. The level transitions by detecting collision with the player with an invisible box in the Lift prefab. This script has fixed scenes that loads depends on 
        //what the invisible box detects first
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(15);
        }
        if (other.gameObject.tag == "Parabox")
        {
            SceneManager.LoadScene(16);
        }
    }
}
