using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonEnd2 : MonoBehaviour
{
    public GameObject piston;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z == 3.77f)
        {
            StartCoroutine(MoveOverSeconds(piston, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1), 0.2f));
        }
        if (transform.position.z == 6.77f)
        {
            StartCoroutine(MoveOverSeconds(piston, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 2), 0.2f));
        }
    }
    public IEnumerator MoveOverSpeed(GameObject piston, Vector3 end, float speed)
    {

        while (piston.transform.position != end)
        {
            piston.transform.position = Vector3.MoveTowards(piston.transform.position, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator MoveOverSeconds(GameObject piston, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = piston.transform.position;
        while (elapsedTime < seconds)
        {
            piston.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / 0.2f));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        piston.transform.position = end;
    }

}
