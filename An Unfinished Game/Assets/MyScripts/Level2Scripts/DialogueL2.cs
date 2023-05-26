using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueL2 : MonoBehaviour
{
    public GameObject line1;

    
    void Start()
    {
        line1.SetActive(false);
        StartCoroutine(linesL2());
    }

   
    IEnumerator linesL2()
    {
        yield return new WaitForSeconds(10f);
        line1.SetActive(true);
        yield return new WaitForSeconds(5f);
        line1.SetActive(false);
    }
}
