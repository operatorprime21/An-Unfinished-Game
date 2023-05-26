using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrbDestroy : MonoBehaviour
{
    // Destroying hazardous projectiles to avoid clogging up the game with objects
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "stick")
        {
            //A defense mechanism that requires a certain object that instantly destroys the hazard
            Destroy(gameObject);
            Debug.Log("!");
        }
    }
}
