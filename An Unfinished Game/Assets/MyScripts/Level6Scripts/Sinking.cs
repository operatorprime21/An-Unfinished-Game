using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinking : MonoBehaviour
{
    public GameObject floor1;
    public GameObject floor2;
    //An initial plan for Level 6 was to make platforms fall or move. Of course this makes for a horrid experience with how the level relies on the teleporter object, which already led to the decision for the specific
    //Level 6 skip option in the menu. This is purely a remnant of that attempt playing with moving platform. 
    void Start()
    {
        StartCoroutine(Floor1Move(floor1, new Vector3(floor1.transform.position.x, floor1.transform.position.y -2, floor1.transform.position.z ), 20f));
        StartCoroutine(Floor2Move(floor2, new Vector3(floor2.transform.position.x, floor2.transform.position.y -2, floor2.transform.position.z ), 20f));
    }
    public IEnumerator Floor1MoveSpeed(GameObject floor1, Vector3 end, float speed)
    {
        floor1.transform.position = Vector3.MoveTowards(floor1.transform.position, end, 50000f * Time.deltaTime);
        yield return new WaitForEndOfFrame();
    }
    public IEnumerator Floor1Move(GameObject floor1, Vector3 end, float seconds)
    {
        float doorMoveTime = 0f;
        while (doorMoveTime <= seconds)
        {
            floor1.transform.position = Vector3.Lerp(floor1.transform.position, end, (doorMoveTime / 2000f));
            doorMoveTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        floor1.transform.position = end;
    }
    public IEnumerator Floor2MoveSpeed(GameObject floor2, Vector3 end, float speed)
    {
        floor2.transform.position = Vector3.MoveTowards(floor2.transform.position, end, 5000000f * Time.deltaTime);
        yield return new WaitForEndOfFrame();
    }
    public IEnumerator Floor2Move(GameObject floor2, Vector3 end, float seconds)
    {
        float doorMoveTime = 0f;
        while (doorMoveTime <= seconds)
        {
            floor2.transform.position = Vector3.Lerp(floor2.transform.position, end, (doorMoveTime / 2000f));
            doorMoveTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        floor2.transform.position = end;
    }
}

    

