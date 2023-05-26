using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad5 : MonoBehaviour
{
    public GameObject Door1;
    private int cardCount = 0;
    bool doorOpened = false;
    bool triggerIsDisabled = false;
    public Collider doorHitBox;
    bool redKeyChecked;
    bool greenKeyChecked;
    public AudioClip doorClip;
    //These pads are where collision gets extremely weird that required an EXCESSIVE amount of bools and coroutines to make sure things don't go out of wack since it requires MULTIPLE collisions at the same time. 
    void Start()
    {
        doorHitBox = Door1.GetComponent<Collider>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (doorOpened == false && triggerIsDisabled == false)
        {
            StartCoroutine(CollideDelay());

            if (other.gameObject.tag == "RedKey" && cardCount < 1)
            {
                redKeyChecked = true;
                cardCount = cardCount + 1;
                
                Debug.Log("card count :" + cardCount);
            }
            else if (cardCount < 2 && other.gameObject.tag == "GreenKey" && redKeyChecked == true)
            {
                cardCount = cardCount + 1;
                
                Debug.Log("card count :" + cardCount);
                greenKeyChecked = true;
                StartCoroutine(Door1Move(Door1, new Vector3(Door1.transform.position.x, Door1.transform.position.y + 3, Door1.transform.position.z), 3f));
                StartCoroutine(DoorOpenDelay());
                Debug.Log("Opened");
            }
        
            if (other.gameObject.tag == "GreenKey" && cardCount < 1)
            {
                greenKeyChecked = true;
                cardCount = cardCount + 1;
                
                Debug.Log("card count :" + cardCount);
            }
            else if (cardCount < 2 && other.gameObject.tag == "RedKey" && greenKeyChecked == true)
            {
                cardCount = cardCount + 1;
                
                Debug.Log("card count :" + cardCount);
                redKeyChecked = true;
                StartCoroutine(Door1Move(Door1, new Vector3(Door1.transform.position.x, Door1.transform.position.y + 3, Door1.transform.position.z), 3f));
                StartCoroutine(DoorOpenDelay());
                Debug.Log("Opened");
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (triggerIsDisabled == false)
        {
            StartCoroutine(CollideDelay());
            if (cardCount < 3 && doorOpened == true && other.gameObject.tag == "RedKey" && redKeyChecked == true)
            {
                StartCoroutine(Door1Move(Door1, new Vector3(Door1.transform.position.x, Door1.transform.position.y - 3, Door1.transform.position.z), 3f));
                StartCoroutine(DoorCloseDelay());
                Debug.Log("Closing");
                cardCount--;
                Debug.Log("Acard count :" + cardCount);
                redKeyChecked = false;
                
            }
            else if (cardCount < 2 && other.gameObject.tag == "GreenKey" && greenKeyChecked == true)
            {
                greenKeyChecked = false;
                cardCount--;
                
                Debug.Log("Bcard count :" + cardCount);
            }

            if (cardCount < 3 && doorOpened == true && other.gameObject.tag == "GreenKey" && greenKeyChecked == true)
            {
                StartCoroutine(Door1Move(Door1, new Vector3(Door1.transform.position.x, Door1.transform.position.y - 3, Door1.transform.position.z), 3f));
                StartCoroutine(DoorCloseDelay());
                Debug.Log("Closing");
                cardCount--;
                Debug.Log("Acard count :" + cardCount);
                greenKeyChecked = false;
                
            }
            else if (cardCount < 2 && other.gameObject.tag == "RedKey" && redKeyChecked == true)
            {
                redKeyChecked = false;
                cardCount--;
                
                Debug.Log("Bcard count :" + cardCount);
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
        doorHitBox.isTrigger = true;
    }

    IEnumerator DoorCloseDelay()
    {
        
        yield return new WaitForSeconds(2f);
        doorOpened = false;
        doorHitBox.isTrigger = false;
    }

    IEnumerator CollideDelay()
    {
        triggerIsDisabled = true;
        yield return new WaitForSeconds(1f);
        triggerIsDisabled = false;
    }
}