using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleButton : MonoBehaviour
{
    public GameObject PurpleDoorA;
    public GameObject PurpleDoorB;
    public AudioClip DoorClip;
    public AudioClip boxClip;
    void OnCollisionEnter(Collision ObjectCollidedWith)
    {
        AudioSource.PlayClipAtPoint(boxClip, this.transform.position);
        if (PurpleDoorA.transform.position.y == 3.87f)
        {
            StartCoroutine(DoorAMove(PurpleDoorA, new Vector3(PurpleDoorA.transform.position.x, PurpleDoorA.transform.position.y + 5, PurpleDoorA.transform.position.z), 5f));
            StartCoroutine(DoorBMove(PurpleDoorB, new Vector3(PurpleDoorB.transform.position.x, PurpleDoorB.transform.position.y + 5, PurpleDoorB.transform.position.z), 5f));
            AudioSource.PlayClipAtPoint(DoorClip, PurpleDoorA.transform.position);
            AudioSource.PlayClipAtPoint(DoorClip, PurpleDoorB.transform.position);
        }
        if (PurpleDoorA.transform.position.y == 8.87f)
        {
            StartCoroutine(DoorAMove(PurpleDoorA, new Vector3(PurpleDoorA.transform.position.x, PurpleDoorA.transform.position.y - 5, PurpleDoorA.transform.position.z), 5f));
            StartCoroutine(DoorBMove(PurpleDoorB, new Vector3(PurpleDoorB.transform.position.x, PurpleDoorB.transform.position.y - 5, PurpleDoorB.transform.position.z), 5f));
            AudioSource.PlayClipAtPoint(DoorClip, PurpleDoorA.transform.position);
            AudioSource.PlayClipAtPoint(DoorClip, PurpleDoorB.transform.position);
        }
    }

    IEnumerator DoorMoveASpeed(GameObject PurpleDoorA, Vector3 end, float speed)
    {
        PurpleDoorA.transform.position = Vector3.MoveTowards(PurpleDoorA.transform.position, end, 100f * Time.deltaTime);
        yield return new WaitForEndOfFrame();
    }
    IEnumerator DoorMoveBSpeed(GameObject PurpleDoorB, Vector3 end, float speed)
    {
        PurpleDoorB.transform.position = Vector3.MoveTowards(PurpleDoorB.transform.position, end, 100f * Time.deltaTime);
        yield return new WaitForEndOfFrame();
    }
    IEnumerator DoorAMove(GameObject PurpleDoorA, Vector3 end, float seconds)
    {
        float doorMoveTime = 0f;
        while (doorMoveTime <= seconds)
        {
            PurpleDoorA.transform.position = Vector3.Lerp(PurpleDoorA.transform.position, end, (doorMoveTime / 200f));
            doorMoveTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        PurpleDoorA.transform.position = end;
    }

    IEnumerator DoorBMove(GameObject PurpleDoorB, Vector3 end, float seconds)
    {
        float doorMoveTime = 0f;
        while (doorMoveTime <= seconds)
        {
            PurpleDoorB.transform.position = Vector3.Lerp(PurpleDoorB.transform.position, end, (doorMoveTime / 200f));
            doorMoveTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        PurpleDoorB.transform.position = end;
    }
}

