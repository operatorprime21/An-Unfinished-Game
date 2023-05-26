using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueButton : MonoBehaviour
{
    //An example of using lerp, controlling movement speed, time, animation duration excessively to control the puzzles. The scripts are split and given separate names to avoid confusion
    //and make sure any particular difference between elements do not screw up the others
    public GameObject BlueDoorA;
    public GameObject BlueDoorB;
    public AudioClip DoorClip;
    public AudioClip boxClip;
    void OnCollisionEnter(Collision ObjectCollidedWith)
    {
        AudioSource.PlayClipAtPoint(boxClip, this.transform.position);
        if (BlueDoorA.transform.position.y == 8.87f)
        {
            StartCoroutine(DoorAMove(BlueDoorA, new Vector3(BlueDoorA.transform.position.x, BlueDoorA.transform.position.y - 5, BlueDoorA.transform.position.z), 5f));
            AudioSource.PlayClipAtPoint(DoorClip, BlueDoorA.transform.position);
            StartCoroutine(DoorBMove(BlueDoorB, new Vector3(BlueDoorB.transform.position.x, BlueDoorB.transform.position.y + 5, BlueDoorB.transform.position.z), 5f));
            AudioSource.PlayClipAtPoint(DoorClip, BlueDoorB.transform.position);
        }
        if (BlueDoorA.transform.position.y == 3.87f)
        {
            StartCoroutine(DoorAMove(BlueDoorA, new Vector3(BlueDoorA.transform.position.x, BlueDoorA.transform.position.y + 5, BlueDoorA.transform.position.z), 5f));
            AudioSource.PlayClipAtPoint(DoorClip, BlueDoorA.transform.position);
            StartCoroutine(DoorBMove(BlueDoorB, new Vector3(BlueDoorB.transform.position.x, BlueDoorB.transform.position.y - 5, BlueDoorB.transform.position.z), 5f));
            AudioSource.PlayClipAtPoint(DoorClip, BlueDoorB.transform.position);
        }
    }

    IEnumerator DoorAMoveSpeed(GameObject BlueDoorA, Vector3 end, float speed)
    {
        BlueDoorA.transform.position = Vector3.MoveTowards(BlueDoorA.transform.position, end, 100f * Time.deltaTime);
        yield return new WaitForEndOfFrame();
    }
    IEnumerator DoorBMoveSpeed(GameObject BlueDoorB, Vector3 end, float speed)
    {
        BlueDoorB.transform.position = Vector3.MoveTowards(BlueDoorB.transform.position, end, 100f * Time.deltaTime);
        yield return new WaitForEndOfFrame();
    }

    IEnumerator DoorAMove(GameObject BlueDoorA, Vector3 end, float seconds)
    {
        float doorMoveTime = 0f;
        while (doorMoveTime <= seconds)
        {
            BlueDoorA.transform.position = Vector3.Lerp(BlueDoorA.transform.position, end, (doorMoveTime / 200f));
            doorMoveTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        BlueDoorA.transform.position = end;
    }

    IEnumerator DoorBMove(GameObject BlueDoorB, Vector3 end, float seconds)
    {
        float doorMoveTime = 0f;
        while (doorMoveTime <= seconds)
        {
            BlueDoorB.transform.position = Vector3.Lerp(BlueDoorB.transform.position, end, (doorMoveTime / 200f));
            doorMoveTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        BlueDoorB.transform.position = end;
    }
}