using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2 : MonoBehaviour
{
    public GameObject monster;
    
    public float movementTime = 10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FirstWait());
    }

    // Update is called once per frame
   
    public IEnumerator FirstWait()
    {
        yield return new WaitForSeconds(14f);
        GameObject monsterG2 = Instantiate(monster, new Vector3(this.transform.position.x, this.transform.position.y + 6f, this.transform.position.z - 20f), this.transform.rotation);
        StartCoroutine(Route(monsterG2, new Vector3(this.transform.position.x , this.transform.position.y + 6f, this.transform.position.z + 20f), 10f));
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(28f);
        GameObject monsterG2 = Instantiate(monster, new Vector3(this.transform.position.x , this.transform.position.y + 6f, this.transform.position.z -20f), this.transform.rotation);
        StartCoroutine(Route(monsterG2, new Vector3(this.transform.position.x , this.transform.position.y + 6f, this.transform.position.z + 20f), 10f));
    }
    public IEnumerator MoveOverSpeed(GameObject monsterG2, Vector3 end, float speed)
    {

        while (monsterG2.transform.position != end)
        {
            monsterG2.transform.position = Vector3.MoveTowards(monsterG2.transform.position, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator Route(GameObject monsterG2, Vector3 end, float seconds)
    {
        StartCoroutine(Wait());
        yield return new WaitForSeconds(2f);
        float elapsedTime = 0;
        Vector3 startingPos = monsterG2.transform.position;
        while (elapsedTime < seconds)
        {
            monsterG2.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / movementTime));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        monsterG2.transform.position = end;
        Destroy(monsterG2, 2f);
    }
}
