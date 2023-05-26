using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Dead");
            SceneManager.LoadScene(20);
            //a simple kill script in the case player falls into a hazardous environment or get caught by enemies
        }
    }
}
