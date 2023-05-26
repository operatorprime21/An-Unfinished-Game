using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    public GameObject RedDoorA;
    public GameObject RedDoorB;
    public AudioClip DoorClip;
    public AudioClip boxClip;
    void OnCollisionEnter(Collision ObjectCollidedWith)
    {
        AudioSource.PlayClipAtPoint(boxClip, this.transform.position);
        if (RedDoorA.transform.position.y == 8.87f)
        {
            StartCoroutine(DoorAMove(RedDoorA, new Vector3(RedDoorA.transform.position.x, RedDoorA.transform.position.y - 5, RedDoorA.transform.position.z), 5f));
            StartCoroutine(DoorBMove(RedDoorB, new Vector3(RedDoorB.transform.position.x, RedDoorB.transform.position.y + 5, RedDoorB.transform.position.z), 5f));
            AudioSource.PlayClipAtPoint(DoorClip, RedDoorA.transform.position);
            AudioSource.PlayClipAtPoint(DoorClip, RedDoorB.transform.position);
        }
        if (RedDoorA.transform.position.y == 3.87f)
        {
            StartCoroutine(DoorAMove(RedDoorA, new Vector3(RedDoorA.transform.position.x, RedDoorA.transform.position.y + 5, RedDoorA.transform.position.z), 5f));
            StartCoroutine(DoorBMove(RedDoorB, new Vector3(RedDoorB.transform.position.x, RedDoorB.transform.position.y - 5, RedDoorB.transform.position.z), 5f));
            AudioSource.PlayClipAtPoint(DoorClip, RedDoorA.transform.position);
            AudioSource.PlayClipAtPoint(DoorClip, RedDoorB.transform.position);
        }
    }

    IEnumerator DoorAMoveSpeed(GameObject RedDoorA, Vector3 end, float speed)
    {
        RedDoorA.transform.position = Vector3.MoveTowards(RedDoorA.transform.position, end, 100f * Time.deltaTime);
        yield return new WaitForEndOfFrame();
    }
    IEnumerator DoorBMoveSpeed(GameObject RedDoorB, Vector3 end, float speed)
    {
        RedDoorB.transform.position = Vector3.MoveTowards(RedDoorB.transform.position, end, 100f * Time.deltaTime);
        yield return new WaitForEndOfFrame();
    }

    IEnumerator DoorAMove(GameObject RedDoorA, Vector3 end, float seconds)
    {
        float doorMoveTime = 0f;
        while (doorMoveTime <= seconds)
        {
            RedDoorA.transform.position = Vector3.Lerp(RedDoorA.transform.position, end, (doorMoveTime / 200f));
            doorMoveTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        RedDoorA.transform.position = end;
    }

    IEnumerator DoorBMove(GameObject RedDoorB, Vector3 end, float seconds)
    {
        float doorMoveTime = 0f;
        while (doorMoveTime <= seconds)
        {
            RedDoorB.transform.position = Vector3.Lerp(RedDoorB.transform.position, end, (doorMoveTime / 200f));
            doorMoveTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        RedDoorB.transform.position = end;
    }
}
