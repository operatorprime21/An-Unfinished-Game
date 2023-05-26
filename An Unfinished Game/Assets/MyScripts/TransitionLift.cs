using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionLift: MonoBehaviour
{

    //Lift that takes the player into the next level.
    public GameObject transitionLift;
    public AudioClip liftClip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Parabox")
        {
            //This is the key to the good ending of the game, where the player let the Parabox go up the lift instead of themselves.
            StartCoroutine(MoveOverSeconds(gameObject, new Vector3(this.transform.position.x, this.transform.position.y + 20, this.transform.position.z), 10f));
            AudioSource.PlayClipAtPoint(liftClip, this.transform.position);
            other.transform.parent = transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            other.transform.parent = null;
        }
    }
    public IEnumerator MoveOverSpeed(GameObject transitionLift, Vector3 end, float speed)
    {

        while (transitionLift.transform.position != end)
        {
            transitionLift.transform.position = Vector3.MoveTowards(transitionLift.transform.position, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator MoveOverSeconds(GameObject transitionLift, Vector3 end, float seconds)
    {
        //Lift animation
        float elapsedTime = 0;
        Vector3 startingPos = transitionLift.transform.position;
        while (elapsedTime < seconds)
        {
            transitionLift.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / 10f));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transitionLift.transform.position = end;
    }
    
}

