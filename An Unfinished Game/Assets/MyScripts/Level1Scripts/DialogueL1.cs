using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueL1 : MonoBehaviour
{
    //An excessive amount of dialogue requires an excessive amount of subtitles. 
    public GameObject line1;
    public GameObject line2;
    public GameObject line3;
    public GameObject line4;
    public GameObject line5;
    public GameObject line6;
    public GameObject line7;
    
   
    void Start()
    {
        line1.SetActive(false);
        line2.SetActive(false);
        line3.SetActive(false);
        line4.SetActive(false);
        line5.SetActive(false);
        line6.SetActive(false);
        line7.SetActive(false);
        StartCoroutine(linesL1());
        
    }

   
    void Update()
    {
        
    }
    IEnumerator linesL1()
    {
        yield return new WaitForSeconds(2.2f);
        line1.SetActive(true);
        yield return new WaitForSeconds(6.8f);
        line1.SetActive(false);
        line2.SetActive(true);
        yield return new WaitForSeconds(3f);
        line2.SetActive(false);
        line3.SetActive(true);
        yield return new WaitForSeconds(3f);
        line3.SetActive(false);
        line4.SetActive(true);
        yield return new WaitForSeconds(7f);
        line4.SetActive(false);
        line5.SetActive(true);
        yield return new WaitForSeconds(9f);
        line5.SetActive(false);
        line6.SetActive(true);
        yield return new WaitForSeconds(5f);
        line6.SetActive(false);
        line7.SetActive(true);
        yield return new WaitForSeconds(3f);
        line7.SetActive(false);
    }
}
