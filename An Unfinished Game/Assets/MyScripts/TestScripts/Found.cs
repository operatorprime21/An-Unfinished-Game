using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Found : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;
    // This was the attempt at making a proper chasing monster. While it works to an extent it conflicts too much with other movement script hence was left out.
    
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Chase(monster, new Vector3(player.transform.position.x +5f, player.transform.position.y + 3f, player.transform.position.z), 1000f));
            Debug.Log("Seen");
        }
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
        
       
        float elapsedTime = 0;
        Vector3 startingPos = monster.transform.position;
        while (elapsedTime < seconds)
        {
            monster.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / 2f));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        monster.transform.position = end;
        
    }
}
