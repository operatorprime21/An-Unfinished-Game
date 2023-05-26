using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDropTrig : MonoBehaviour
{
    public GameObject line2;
    bool hinted = false;
    public GameObject Path;
    public GameObject d2;
    public AudioClip bridge;
    //This simulates the part where the bridge breaks creating a gap the player must cross. The janky physics system can make this extremely odd since how collision dependent the game is
    void Start()
    {
        line2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DropEvent" && hinted == false)
        {
            other.attachedRigidbody.useGravity = true;
            StartCoroutine(L3dialogue());
            hinted = true;
            AudioSource.PlayClipAtPoint(bridge, this.transform.position);
        }
    }
    IEnumerator L3dialogue()
    {
        d2.SetActive(true);
        yield return new WaitForSeconds(1f);
        line2.SetActive(true);
        yield return new WaitForSeconds(10f);
        line2.SetActive(false);
    }
}
