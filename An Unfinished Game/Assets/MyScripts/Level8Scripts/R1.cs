using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R1 : MonoBehaviour
{
    public GameObject monster;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FirstWait());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator FirstWait()
    {
        yield return new WaitForSeconds(28f);
        GameObject monsterG2 = Instantiate(monster, new Vector3(this.transform.position.x, this.transform.position.y + 6f, this.transform.position.z + 12f), this.transform.rotation);
        StartCoroutine(Route(monsterG2, new Vector3(this.transform.position.x, this.transform.position.y + 6f, this.transform.position.z - 12f), 10f));
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(54f);
        GameObject monsterG2 = Instantiate(monster, new Vector3(this.transform.position.x, this.transform.position.y + 6f, this.transform.position.z + 12f), this.transform.rotation);
        StartCoroutine(Route(monsterG2, new Vector3(this.transform.position.x, this.transform.position.y + 6f, this.transform.position.z - 12f), 10f));
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
            monsterG2.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / 10f));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        monsterG2.transform.position = end;
        Destroy(monsterG2, 2f);
    }
}

