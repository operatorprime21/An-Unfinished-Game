using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3 : MonoBehaviour
{
    bool spawned = false;
    public GameObject imperfect;
    public GameObject Player;
    public GameObject YellowCard;
    public GameObject BlueCard;
    public GameObject RedCard;
    public GameObject PurpleCard;
    public GameObject GreenCard;
    public GameObject scream2;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), Player.GetComponent<Collider>());
        Physics.IgnoreCollision(GetComponent<Collider>(), YellowCard.GetComponent<Collider>());
        Physics.IgnoreCollision(GetComponent<Collider>(), BlueCard.GetComponent<Collider>());
        Physics.IgnoreCollision(GetComponent<Collider>(), RedCard.GetComponent<Collider>());
        Physics.IgnoreCollision(GetComponent<Collider>(), PurpleCard.GetComponent<Collider>());
        Physics.IgnoreCollision(GetComponent<Collider>(), GreenCard.GetComponent<Collider>());
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "stick" && spawned == false)
        {
            StartCoroutine(Turn());
            Debug.Log("New Event");
            spawned = true;
            scream2.SetActive(true);
        }
    }
    IEnumerator Turn()
    {
        yield return new WaitForSeconds(0.3f);
        GameObject monster = Instantiate(imperfect, new Vector3(this.transform.position.x, this.transform.position.y + 4f, this.transform.position.z), this.transform.rotation);
        StartCoroutine(Chase(monster, new Vector3(this.transform.position.x + 0f, this.transform.position.y + 4f, this.transform.position.z + 10f), 1f));
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
            monster.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / 1f));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        monster.transform.position = end;
    }

}

