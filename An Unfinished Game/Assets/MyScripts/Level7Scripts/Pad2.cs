using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad2 : MonoBehaviour
{
    public GameObject Door2;
    bool doorOpened = false;
    bool triggerIsDisabled = false;
    public AudioClip doorClip;
    //These pads are where collision gets extremely weird that required an EXCESSIVE amount of bools and coroutines to make sure things don't go out of wack since it requires MULTIPLE collisions at the same time. 

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "RedKey" && doorOpened == false && triggerIsDisabled == false)
        {
            StartCoroutine(CollideDelay());
            StartCoroutine(Door2Move(Door2, new Vector3(Door2.transform.position.x, Door2.transform.position.y + 3, Door2.transform.position.z), 3f));
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
            StartCoroutine(Door2Move(Door2, new Vector3(Door2.transform.position.x, Door2.transform.position.y - 3, Door2.transform.position.z), 3f));
          
            Debug.Log("Closing");
        }
    }

    IEnumerator DoorMoveSpeed(GameObject Door2, Vector3 end, float speed)
    {
        Door2.transform.position = Vector3.MoveTowards(Door2.transform.position, end, 1000f * Time.deltaTime);
        yield return new WaitForEndOfFrame();
    }

    IEnumerator Door2Move(GameObject Door2, Vector3 end, float seconds)
    {
        AudioSource.PlayClipAtPoint(doorClip, this.transform.position);
        float doorMoveTime = 0f;
        while (doorMoveTime <= seconds)
        {
            Door2.transform.position = Vector3.Lerp(Door2.transform.position, end, (doorMoveTime / 200f));
            doorMoveTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Door2.transform.position = end;
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

