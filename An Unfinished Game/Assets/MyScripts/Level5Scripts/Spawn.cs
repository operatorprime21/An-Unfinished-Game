using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject imperfect;
    public GameObject screams;
    public GameObject chaseTrack;
    //First instance of using a monster to chase down players. Even this uses fixed movement with Lerp. 
    //Also "imperfect" is a placeholder/early name to call the prefab "guy" which is essentially the monster. Some early lore reasons in there but that was eventually scrapped so this is just here to clarify.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Prepare());
            
        }
    }
    IEnumerator Prepare()
    {
        Debug.Log("Monster spawning, you are 2 seconds ahead in distance");
        yield return new WaitForSeconds(2f);
        GameObject monster = Instantiate(imperfect, new Vector3(this.transform.position.x, this.transform.position.y +4.8f, this.transform.position.z), this.transform.rotation);
        
        StartCoroutine(Chase(monster, new Vector3(this.transform.position.x +70f, this.transform.position.y +32f, this.transform.position.z), 4.5f));
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
        screams.SetActive(true);
        yield return new WaitForSeconds(2f);
        chaseTrack.SetActive(true);
        float elapsedTime = 0;
        Vector3 startingPos = monster.transform.position;
        while (elapsedTime < seconds)
        {
            monster.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / 4.5f));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        monster.transform.position = end;
    }
}
