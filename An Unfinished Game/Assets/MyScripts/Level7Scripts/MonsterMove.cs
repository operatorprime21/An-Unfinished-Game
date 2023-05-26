using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public GameObject imperfect;
    bool spawned = false;
    public GameObject scream2;
    
    
    private void OnTriggerEnter(Collider other)
    {
        //Most scripts involving the monster in this level are largely an attempt to simulate a more believable chase, making it turn corners and such. 
        //In actuality they are just instantiating the monster, make it move, then spawning another at the destination of the previous while destroying the previous. The new one then turns direction and continue from where 
        //the last left off. I guess its kinda successful? This part of the level is mega scuffed considering there is a part where players must close a door to stop it but it works like half the time. 
        if (other.gameObject.tag == "stick" && spawned == false)
        {
            StartCoroutine(Turn());
            spawned = true;
        }
    }
    IEnumerator Turn()
    {
        yield return new WaitForSeconds(0.3f);
        GameObject monster = Instantiate(imperfect, new Vector3(this.transform.position.x, this.transform.position.y + 4f, this.transform.position.z), this.transform.rotation);
        StartCoroutine(Chase(monster, new Vector3(this.transform.position.x + 25f, this.transform.position.y + 4f, this.transform.position.z ), 2.5f));
        scream2.SetActive(true);
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
            monster.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / 2.5f));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        monster.transform.position = end;
        Destroy(monster, 0f);
    }
    
}
