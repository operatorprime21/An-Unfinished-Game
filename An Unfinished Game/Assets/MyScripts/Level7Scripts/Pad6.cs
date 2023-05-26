using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad6 : MonoBehaviour
{
    public GameObject Door1;
    
    bool doorOpened = false;
    bool triggerIsDisabled = false;
    public AudioClip doorClip;
    bool yellowKeyChecked;
    bool greenKeyChecked;
    bool blueKeyChecked;
    //These pads are where collision gets extremely weird that required an EXCESSIVE amount of bools and coroutines to make sure things don't go out of wack since it requires MULTIPLE collisions at the same time. 

    void OnTriggerEnter(Collider other)
    {
        if (doorOpened == false && triggerIsDisabled == false)
        {
            StartCoroutine(CollideDelay());

            if (other.gameObject.tag == "BlueKey" )
            {
                blueKeyChecked = true; 
            }
            else if (other.gameObject.tag == "GreenKey" && blueKeyChecked == true)
            {
                greenKeyChecked = true;
                if (yellowKeyChecked == true && blueKeyChecked == true && greenKeyChecked == true)
                {
                    StartCoroutine(Door1Move(Door1, new Vector3(Door1.transform.position.x, Door1.transform.position.y + 3, Door1.transform.position.z), 3f));
                    StartCoroutine(DoorOpenDelay());
                    Debug.Log("Opened");
                }
            }
            else if (other.gameObject.tag == "YellowKey" && blueKeyChecked == true)
            {  
                yellowKeyChecked = true;
                if (yellowKeyChecked == true && blueKeyChecked == true && greenKeyChecked == true)
                {
                    StartCoroutine(Door1Move(Door1, new Vector3(Door1.transform.position.x, Door1.transform.position.y + 3, Door1.transform.position.z), 3f));
                    StartCoroutine(DoorOpenDelay());
                    Debug.Log("Opened");
                } 
            }

            if (other.gameObject.tag == "GreenKey" )
            {
                greenKeyChecked = true;
            }
            else if (other.gameObject.tag == "BlueKey" && greenKeyChecked == true)
            {
                blueKeyChecked = true;
                if (yellowKeyChecked == true && blueKeyChecked == true && greenKeyChecked == true)
                {
                    StartCoroutine(Door1Move(Door1, new Vector3(Door1.transform.position.x, Door1.transform.position.y + 3, Door1.transform.position.z), 3f));
                    StartCoroutine(DoorOpenDelay());
                    Debug.Log("Opened");
                }
            }
            else if (other.gameObject.tag == "YellowKey" && greenKeyChecked == true)
            { 
                yellowKeyChecked = true;
                if (yellowKeyChecked == true && blueKeyChecked == true && greenKeyChecked == true)
                {
                    StartCoroutine(Door1Move(Door1, new Vector3(Door1.transform.position.x, Door1.transform.position.y + 3, Door1.transform.position.z), 3f));
                    StartCoroutine(DoorOpenDelay());
                    Debug.Log("Opened");
                }
            }


            if (other.gameObject.tag == "YellowKey" )
            {
                yellowKeyChecked = true;
            }
            else if (other.gameObject.tag == "BlueKey" && yellowKeyChecked == true)
            {
                blueKeyChecked = true;
                if (yellowKeyChecked == true && blueKeyChecked == true && greenKeyChecked == true)
                {
                    StartCoroutine(Door1Move(Door1, new Vector3(Door1.transform.position.x, Door1.transform.position.y + 3, Door1.transform.position.z), 3f));
                    StartCoroutine(DoorOpenDelay());
                    Debug.Log("Opened");
                }
            }
            else if (other.gameObject.tag == "GreenKey" && yellowKeyChecked == true)
            {
                greenKeyChecked = true;
                if (yellowKeyChecked == true && blueKeyChecked == true && greenKeyChecked == true)
                {
                    StartCoroutine(Door1Move(Door1, new Vector3(Door1.transform.position.x, Door1.transform.position.y + 3, Door1.transform.position.z), 3f));
                    StartCoroutine(DoorOpenDelay());
                    Debug.Log("Opened");
                }
            }
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (triggerIsDisabled == false)
        {
            StartCoroutine(CollideDelay());
            if (other.gameObject.tag == "BlueKey")
            {
                blueKeyChecked = false;
            }
            if (other.gameObject.tag == "GreenKey")
            {
                greenKeyChecked = false;
            }
            if (other.gameObject.tag == "YellowKey")
            {
                yellowKeyChecked = false;
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