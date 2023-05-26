using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenButton : MonoBehaviour
{
    public GameObject GreenDoorA;
    public GameObject GreenDoorB;
    public AudioClip DoorClip;
    public AudioClip boxClip;
    void OnCollisionEnter(Collision ObjectCollidedWith)
    {
        AudioSource.PlayClipAtPoint(boxClip, this.transform.position);
        if (GreenDoorA.transform.position.y == 8.87f)
        {
            StartCoroutine(DoorAMove(GreenDoorA, new Vector3(GreenDoorA.transform.position.x, GreenDoorA.transform.position.y - 5, GreenDoorA.transform.position.z), 5f));
            StartCoroutine(DoorBMove(GreenDoorB, new Vector3(GreenDoorB.transform.position.x, GreenDoorB.transform.position.y + 5, GreenDoorB.transform.position.z), 5f));
            AudioSource.PlayClipAtPoint(DoorClip, GreenDoorA.transform.position);
            AudioSource.PlayClipAtPoint(DoorClip, GreenDoorB.transform.position);
        }
        if (GreenDoorA.transform.position.y == 3.87f)
        {
            StartCoroutine(DoorAMove(GreenDoorA, new Vector3(GreenDoorA.transform.position.x, GreenDoorA.transform.position.y + 5, GreenDoorA.transform.position.z), 5f));
            StartCoroutine(DoorBMove(GreenDoorB, new Vector3(GreenDoorB.transform.position.x, GreenDoorB.transform.position.y - 5, GreenDoorB.transform.position.z), 5f));
            AudioSource.PlayClipAtPoint(DoorClip, GreenDoorA.transform.position);
            AudioSource.PlayClipAtPoint(DoorClip, GreenDoorB.transform.position);
        }
    }

    IEnumerator DoorAMoveSpeed(GameObject GreenDoorA, Vector3 end, float speed)
    {
        GreenDoorA.transform.position = Vector3.MoveTowards(GreenDoorA.transform.position, end, 100f * Time.deltaTime);
        yield return new WaitForEndOfFrame();
    }
    IEnumerator DoorBMoveSpeed(GameObject GreenDoorB, Vector3 end, float speed)
    {
        GreenDoorB.transform.position = Vector3.MoveTowards(GreenDoorB.transform.position, end, 100f * Time.deltaTime);
        yield return new WaitForEndOfFrame();
    }

    IEnumerator DoorAMove(GameObject GreenDoorA, Vector3 end, float seconds)
    {
        float doorMoveTime = 0f;
        while (doorMoveTime <= seconds)
        {
            GreenDoorA.transform.position = Vector3.Lerp(GreenDoorA.transform.position, end, (doorMoveTime / 200f));
            doorMoveTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        GreenDoorA.transform.position = end;
    }

    IEnumerator DoorBMove(GameObject GreenDoorB, Vector3 end, float seconds)
    {
        float doorMoveTime = 0f;
        while (doorMoveTime <= seconds)
        {
            GreenDoorB.transform.position = Vector3.Lerp(GreenDoorB.transform.position, end, (doorMoveTime / 200f));
            doorMoveTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        GreenDoorB.transform.position = end;
    }
}
