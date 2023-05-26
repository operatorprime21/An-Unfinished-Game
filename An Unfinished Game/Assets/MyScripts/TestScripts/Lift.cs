using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    
    // Start is called before the first frame update
    public GameObject lift;
    void Update()
    {
        if (transform.position.y == 1)
        {
            StartCoroutine(MoveOverSeconds(gameObject, new Vector3(3.0f, 10f, 0f), 5f));
        }
        if (transform.position.y == 10f)
        {
            StartCoroutine(MoveOverSeconds(gameObject, new Vector3(3.0f, 1f, 0f), 5f));
        }
    }
    
  public IEnumerator MoveOverSpeed(GameObject lift, Vector3 end, float speed)
    {
        
        while (lift.transform.position != end)
        {
            lift.transform.position = Vector3.MoveTowards(lift.transform.position, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator MoveOverSeconds(GameObject lift, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = lift.transform.position;
        while (elapsedTime < seconds)
        {
            lift.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / 5f));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        lift.transform.position = end;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
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
}

