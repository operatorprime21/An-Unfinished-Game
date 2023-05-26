using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowLift : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject transitionLift;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(MoveOverSeconds(gameObject, new Vector3(this.transform.position.x, this.transform.position.y + 18.5f, this.transform.position.z), 5f));
            Debug.Log("Player on lift");
            other.transform.parent = transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player exited lift");
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
        float elapsedTime = 0;
        Vector3 startingPos = transitionLift.transform.position;
        while (elapsedTime < seconds)
        {
            transitionLift.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / 5f));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transitionLift.transform.position = end;
        
    }

}


