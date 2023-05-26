using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OldMenu : MonoBehaviour
{
    //Every script in level 10 folder simply decides what scene gets loaded depends on what ending they got, getting corresponding scenes and such.
    void Start()
    {
        StartCoroutine(Return());
    }
    IEnumerator Return()
    {
        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene(0);
    }
}
