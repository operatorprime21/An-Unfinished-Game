using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEnd : MonoBehaviour
{
    //Every script in level 10 folder simply decides what scene gets loaded depends on what ending they got, getting corresponding scenes and such.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Credits());
        }
    }
    IEnumerator Credits()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(17);
    }
   
}
