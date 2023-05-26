using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
   
    public GameObject Door;
    public AudioClip sparkle;
    public AudioClip doorClip;
   //Detects collision of anything on an electrical fuse, opens a door
    void OnCollisionEnter(Collision ObjectCollidedWith)
    {
        StartCoroutine(DoorMove(Door, new Vector3(Door.transform.position.x, Door.transform.position.y, Door.transform.position.z + 5), 5f));
        AudioSource.PlayClipAtPoint(sparkle, this.transform.position);
        AudioSource.PlayClipAtPoint(doorClip, Door.transform.position);
    }
    public IEnumerator DoorMoveSpeed(GameObject Door, Vector3 end, float speed)
    {
        Door.transform.position = Vector3.MoveTowards(Door.transform.position, end, 100f * Time.deltaTime);
        yield return new WaitForEndOfFrame();
    }
    public IEnumerator DoorMove(GameObject Door, Vector3 end, float seconds)
    {
        
        float doorMoveTime = 0f;
        while (doorMoveTime <= seconds)
        {
            Door.transform.position = Vector3.Lerp(Door.transform.position, end, (doorMoveTime / 200f));
            doorMoveTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Door.transform.position = end;
    }
}
