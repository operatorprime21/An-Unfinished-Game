using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewMenu : MonoBehaviour
{
    //Every script in level 10 folder simply decides what scene gets loaded depends on what ending they got, getting corresponding scenes and such.
    //This one shows the player a new menu, revealing the true title that reveals the metaphorical meaning of the plot. 
    void Start()
    {
        StartCoroutine(End());
    }
    IEnumerator End()
    {
        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene(19);
    }
    
}
