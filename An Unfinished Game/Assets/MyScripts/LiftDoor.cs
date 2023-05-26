using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftDoor : MonoBehaviour
{

    //Script hosts multiple aspects, as detailed below
   
    public GameObject liftDoor;
    public GameObject line1;
    public GameObject introAudio;
    public AudioClip doorClip;
    public float subDuration;
    public float subStartDelay;

    void Start()
    {
        line1.SetActive(false);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Closing the lift door and playing the narration
            AudioSource.PlayClipAtPoint(doorClip, this.transform.position);
            StartCoroutine(MoveOverSeconds(liftDoor, new Vector3(liftDoor.transform.position.x, liftDoor.transform.position.y - 5, liftDoor.transform.position.z), 3f));
            other.transform.parent = transform;
            introAudio.SetActive(true);
            StartCoroutine(linesL2());
        }
    }
    IEnumerator linesL2()
    {
        //Making sure subtitles appear correctly according to the narration. floats are not declared due to the disparity in timing of the voice recordings.
        yield return new WaitForSeconds(subStartDelay);
        line1.SetActive(true);
        yield return new WaitForSeconds(subDuration);
        line1.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
    public IEnumerator MoveOverSpeed(GameObject liftDoor, Vector3 end, float speed)
    {

        while (liftDoor.transform.position != end)
        {
            liftDoor.transform.position = Vector3.MoveTowards(liftDoor.transform.position, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator MoveOverSeconds(GameObject liftDoor, Vector3 end, float seconds)
    {
        //Closing the door. The game is built always using these two functions that decide the position transform, the speed it takes and the duration the animation happens. 
        //This is copy pasted everywhere with variations to avoid complications and ease of manipulation.
        float elapsedTime = 0;
        Vector3 startingPos = liftDoor.transform.position;
        while (elapsedTime < seconds)
        {
            liftDoor.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / 3f));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        liftDoor.transform.position = end;
    }
    
}