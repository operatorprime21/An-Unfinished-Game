using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad3 : MonoBehaviour
{
    public GameObject Door3;
    bool doorOpened = false;
    bool triggerIsDisabled = false;
    public AudioClip doorClip;
    //These pads are where collision gets extremely weird that required an EXCESSIVE amount of bools and coroutines to make sure things don't go out of wack since it requires MULTIPLE collisions at the same time. 

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "RedKey" && doorOpened == false && triggerIsDisabled == false)
        {
            StartCoroutine(CollideDelay());
            StartCoroutine(DoorMove(Door3, new Vector3(Door3.transform.position.x, Door3.transform.position.y + 3, Door3.transform.position.z), 3f));
            StartCoroutine(DoorOpenDelay());
           
            Debug.Log("worked");
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "RedKey" && doorOpened == true && triggerIsDisabled == false)
        {
            StartCoroutine(DoorCloseDelay());
            StartCoroutine(CollideDelay());
            StartCoroutine(DoorMove(Door3, new Vector3(Door3.transform.position.x, Door3.transform.position.y - 3, Door3.transform.position.z), 3f));
           
            Debug.Log("Closing");
        }
    }

    IEnumerator DoorMoveSpeed(GameObject Door3, Vector3 end, float speed)
    {
        Door3.transform.position = Vector3.MoveTowards(Door3.transform.position, end, 1000f * Time.deltaTime);
        yield return new WaitForEndOfFrame();
    }

    IEnumerator DoorMove(GameObject Door3, Vector3 end, float seconds)
    {
        AudioSource.PlayClipAtPoint(doorClip, this.transform.position);
        float doorMoveTime = 0f;
        while (doorMoveTime <= seconds)
        {
            Door3.transform.position = Vector3.Lerp(Door3.transform.position, end, (doorMoveTime / 200f));
            doorMoveTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Door3.transform.position = end;
    }

    IEnumerator DoorOpenDelay()
    {
        yield return new WaitForSeconds(2f);
        doorOpened = true;
    }

    IEnumerator DoorCloseDelay()
    {
        yield return new WaitForSeconds(2f);
        doorOpened = false;
    }


    IEnumerator CollideDelay()
    {
        triggerIsDisabled = true;
        yield return new WaitForSeconds(1f);
        triggerIsDisabled = false;
    }
}