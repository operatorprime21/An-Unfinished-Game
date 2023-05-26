using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1 : MonoBehaviour
{
    public GameObject monster;
    
    public float movementTime = 10f;
    //More excessive Lerp usage here. This is used to hard program fixed patrolling patterns into the monsters that roam level 8. 
    //An attempt was made to simulate a "spotted" event here where movementTime a variable, that would change if the player is detected in line of sight. Of course scrapped due to it resulting in glitchy animations
    void Start()
    {
        GameObject monsterG1 = Instantiate(monster, new Vector3(this.transform.position.x , this.transform.position.y + 6f, this.transform.position.z+20), this.transform.rotation);
        StartCoroutine(Route(monsterG1, new Vector3(this.transform.position.x , this.transform.position.y + 6f, this.transform.position.z -20f), 10f));
    }

    
   
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(28f);
        GameObject monsterG1 = Instantiate(monster, new Vector3(this.transform.position.x , this.transform.position.y + 6f, this.transform.position.z+20), this.transform.rotation);
        StartCoroutine(Route(monsterG1, new Vector3(this.transform.position.x , this.transform.position.y + 6f, this.transform.position.z -20f), 10f));
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
            monsterG1.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / movementTime));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        monsterG1.transform.position = end;
        Destroy(monsterG1, 2f);
    }
}

