using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R3 : MonoBehaviour
{
    public GameObject monster;

    // Start is called before the first frame update
    void Start()
    {
        GameObject monsterG1 = Instantiate(monster, new Vector3(this.transform.position.x - 18f, this.transform.position.y +6f, this.transform.position.z), this.transform.rotation);
        StartCoroutine(Route(monsterG1, new Vector3(this.transform.position.x + 18f, this.transform.position.y + 6f, this.transform.position.z), 10f));
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(54f);
        GameObject monsterG1 = Instantiate(monster, new Vector3(this.transform.position.x - 18f, this.transform.position.y + 6f, this.transform.position.z), this.transform.rotation);
        StartCoroutine(Route(monsterG1, new Vector3(this.transform.position.x + 18f, this.transform.position.y + 6f, this.transform.position.z), 10f));
    }
    public IEnumerator MoveOverSpeed(GameObject monsterG1, Vector3 end, float speed)
    {

        while (monsterG1.transform.position != end)
        {
            monsterG1.transform.position = Vector3.MoveTowards(monsterG1.transform.position, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator Route(GameObject monsterG1, Vector3 end, float seconds)
    {
        StartCoroutine(Wait());
        yield return new WaitForSeconds(2f);
        float elapsedTime = 0;
        Vector3 startingPos = monsterG1.transform.position;
        while (elapsedTime < seconds)
        {
            monsterG1.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / 10f));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        monsterG1.transform.position = end;
        Destroy(monsterG1, 2f);
    }
}
