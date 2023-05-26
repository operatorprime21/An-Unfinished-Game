using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad1 : MonoBehaviour
{
    public GameObject Door1;
    private int cardCount = 0;
    bool doorOpened = false;
    bool triggerIsDisabled = false;
    public AudioClip doorClip;
    public Transform Door1A;
    //These pads are where collision gets extremely weird that required an EXCESSIVE amount of bools and coroutines to make sure things don't go out of wack since it requires MULTIPLE collisions at the same time. 
    
 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "YellowKey" && doorOpened == false && triggerIsDisabled == false)
        {
            StartCoroutine(CollideDelay());

            if (cardCount < 1)
            {
                cardCount = cardCount + 1;
                
                Debug.Log("card count :" + cardCount);
            }
            else if (cardCount < 2)
            {
                cardCount = cardCount + 1;
               
                Debug.Log("card count :" + cardCount);

                StartCoroutine(Door1Move(Door1, new Vector3(Door1.transform.position.x, Door1A.transform.position.y + 3, Door1.transform.position.z), 3f));
                StartCoroutine(DoorOpenDelay());
                Debug.Log("Opened");
            }
        }
    }
    
    void OnTriggerExit(Collider other)
    { 
        if (other.gameObject.tag == "YellowKey" && triggerIsDisabled == false)
        {
            StartCoroutine(CollideDelay());
            
            if (cardCount < 3 && doorOpened == true)
            {
                StartCoroutine(Door1Move(Door1, new Vector3(Door1.transform.position.x, Door1A.transform.position.y - 3, Door1.transform.position.z), 3f));
                StartCoroutine(DoorCloseDelay());
                Debug.Log("Closing");
                cardCount--;
                Debug.Log("card count :" + cardCount);

                
            }
            else if (cardCount < 2)
            {
                cardCount--;
               
                Debug.Log("card count :" + cardCount);
            }
            
        }  
    }

    IEnumerator DoorMoveSpeed(GameObject Door1, Vector3 end, float speed)
    {
        Door1.transform.position = Vector3.MoveTowards(Door1.transform.position, end, 1000f * Time.deltaTime);
        yield return new WaitForEndOfFrame();
    }
   
    IEnumerator Door1Move(GameObject Door1, Vector3 end, float seconds)
    {
        AudioSource.PlayClipAtPoint(doorClip, this.transform.position);
        float doorMoveTime = 0f;
        while (doorMoveTime <= seconds)
        {
            Door1.transform.position = Vector3.Lerp(Door1.transform.position, end, (doorMoveTime / 200f));
            doorMoveTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Door1.transform.position = end;
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
