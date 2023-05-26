using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public GameObject redLights;
    public GameObject greenLights;
    public GameObject dataObj1;
    public GameObject dataObj2;
    public GameObject dataObj3;
    public AudioClip data;
    //Controls the lights of the dup machine by setting active and inactive to their parent objects on fixed time intervals
    void Start()
    {
        redLights.SetActive(false);
        dataObj1.SetActive(false);
        dataObj2.SetActive(false);
        dataObj3.SetActive(false);
    }

   
    void OnCollisionEnter(Collision ObjectCollidedWith)
    {
        StartCoroutine(RedLightsActivation());
    }
    IEnumerator RedLightsActivation()
    {
        yield return new WaitForSeconds(5f);
        AudioSource.PlayClipAtPoint(data, this.transform.position);
        greenLights.SetActive(false);
        dataObj1.SetActive(true);
        dataObj2.SetActive(true);
        dataObj3.SetActive(true);
        yield return new WaitForSeconds(5f);
        dataObj1.SetActive(false);
        dataObj2.SetActive(false);
        dataObj3.SetActive(false);
        redLights.SetActive(true);
        yield return new WaitForSeconds(5f);
        redLights.SetActive(false);
        greenLights.SetActive(true);
    }
}
