using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowButton : MonoBehaviour
{
    public GameObject YellowDoorA;
    public GameObject YellowDoorB;
    public AudioClip DoorClip;
    public AudioClip boxClip;
    void OnCollisionEnter(Collision ObjectCollidedWith)
    {
        AudioSource.PlayClipAtPoint(boxClip, this.transform.position);
        if (YellowDoorA.transform.position.y == 8.87f)
        {
            StartCoroutine(DoorAMove(YellowDoorA, new Vector3(YellowDoorA.transform.position.x, YellowDoorA.transform.position.y - 5, YellowDoorA.transform.position.z), 5f));
            StartCoroutine(DoorBMove(YellowDoorB, new Vector3(YellowDoorB.transform.position.x, YellowDoorB.transform.position.y + 5, YellowDoorB.transform.position.z), 5f));
            AudioSource.PlayClipAtPoint(DoorClip, YellowDoorA.transform.position);
            AudioSource.PlayClipAtPoint(DoorClip, YellowDoorB.transform.position);
        }
        if (YellowDoorA.transform.position.y == 3.87f)
        {
            StartCoroutine(DoorAMove(YellowDoorA, new Vector3(YellowDoorA.transform.position.x, YellowDoorA.transform.position.y + 5, YellowDoorA.transform.position.z), 5f));
            StartCoroutine(DoorBMove(YellowDoorB, new Vector3(YellowDoorB.transform.position.x, YellowDoorB.transform.position.y - 5, YellowDoorB.transform.position.z), 5f));
            AudioSource.PlayClipAtPoint(DoorClip, YellowDoorA.transform.position);
            AudioSource.PlayClipAtPoint(DoorClip, YellowDoorB.transform.position);
        }
    }

    IEnumerator DoorAMoveSpeed(GameObject YellowDoorA, Vector3 end, float speed)
    {
        YellowDoorA.transform.position = Vector3.MoveTowards(YellowDoorA.transform.position, end, 100f * Time.deltaTime);
        yield return new WaitForEndOfFrame();
    }
    IEnumerator DoorBMoveSpeed(GameObject YellowDoorB, Vector3 end, float speed)
    {
        YellowDoorB.transform.position = Vector3.MoveTowards(YellowDoorB.transform.position, end, 100f * Time.deltaTime);
        yield return new WaitForEndOfFrame();
    }

    IEnumerator DoorAMove(GameObject YellowDoorA, Vector3 end, float seconds)
    {
        float doorMoveTime = 0f;
        while (doorMoveTime <= seconds)
        {
            YellowDoorA.transform.position = Vector3.Lerp(YellowDoorA.transform.position, end, (doorMoveTime / 200f));
            doorMoveTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        YellowDoorA.transform.position = end;
    }

    IEnumerator DoorBMove(GameObject YellowDoorB, Vector3 end, float seconds)
    {
        float doorMoveTime = 0f;
        while (doorMoveTime <= seconds)
        {
            YellowDoorB.transform.position = Vector3.Lerp(YellowDoorB.transform.position, end, (doorMoveTime / 200f));
            doorMoveTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        YellowDoorB.transform.position = end;
    }
}