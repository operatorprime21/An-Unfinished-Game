using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoor: MonoBehaviour
{
    //Another totally not necessary element that only somewhat contextualizes the games events
    public GameObject slideDoor;
    public GameObject saw;
    private bool active = true;
    void OnCollisionEnter(Collision ObjectCollidedWith)
    {
        if (active == true)
        {
            StartCoroutine(DoorMove(slideDoor, new Vector3(slideDoor.transform.position.x, slideDoor.transform.position.y + 5, slideDoor.transform.position.z), 3f));
            StartCoroutine(SawMove(saw, new Vector3(saw.transform.position.x, saw.transform.position.y, saw.transform.position.z - 5), 5f));
            active = false;
        }
    }
    public IEnumerator DoorMoveSpeed(GameObject slideDoor, Vector3 end, float speed)
    {
        slideDoor.transform.position = Vector3.MoveTowards(slideDoor.transform.position, end, 100f * Time.deltaTime);
        yield return new WaitForEndOfFrame();
    }
    public IEnumerator DoorMove(GameObject slideDoor, Vector3 end, float seconds)
    {
        float doorMoveTime = 0f;
        while (doorMoveTime <= seconds)
        {
            slideDoor.transform.position = Vector3.Lerp(slideDoor.transform.position, end, (doorMoveTime / 200f));
            doorMoveTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        slideDoor.transform.position = end;
    }
    public IEnumerator SawMoveSpeed(GameObject saw, Vector3 end, float speed)
    {
        saw.transform.position = Vector3.MoveTowards(saw.transform.position, end, 100f * Time.deltaTime);
        yield return new WaitForEndOfFrame();
    }
    public IEnumerator SawMove(GameObject saw, Vector3 end, float seconds)
    {
        float doorMoveTime = 0f;
        while (doorMoveTime <= seconds)
        {
            saw.transform.position = Vector3.Lerp(saw.transform.position, end, (doorMoveTime / 100f));
            doorMoveTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        saw.transform.position = end;
    }
}
