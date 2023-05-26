using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideWithPlayer : MonoBehaviour
{
    public Transform Player;
    public Transform respawn;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(0);
        Debug.Log("Player collision detected");
    }
}
