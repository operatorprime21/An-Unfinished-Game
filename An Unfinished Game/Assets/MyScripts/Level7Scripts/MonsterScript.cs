using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public GameObject imperfect;
    public GameObject scream1;
    void OnTriggerExit(Collider other)
    {
        //I guess this counts as a jumpscare? 
        if (other.gameObject.tag == "PurpleKey")
        {
            StartCoroutine(Prepare());
            scream1.SetActive(true);
        }
    }
    IEnumerator Prepare()
    {
        Debug.Log("Monster spawning, you are 1 seconds ahead in distance");
        yield return new WaitForSeconds(1f);
        GameObject monster = Instantiate(imperfect, new Vector3(this.transform.position.x, this.transform.position.y + 4f, this.transform.position.z), this.transform.rotation);
        StartCoroutine(Chase(monster, new Vector3(this.transform.position.x + 30f, this.transform.position.y + 4f, this.transform.position.z - 30f), 1f));
    }
    public IEnumerator MoveOverSpeed(GameObject monster, Vector3 end, float speed)
    {

        while (monster.transform.position != end)
        {
            monster.transform.position = Vector3.MoveTowards(monster.transform.position, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator Chase(GameObject monster, Vector3 end, float seconds)
    {
        Debug.Log("Monster screaming for 2s, start running");
        yield return new WaitForSeconds(2f);
        float elapsedTime = 0;
        Vector3 startingPos = monster.transform.position;
        while (elapsedTime < seconds)
        {
            monster.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / 2f));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        monster.transform.position = end;
        Destroy(monster, 0f);
    }
}
