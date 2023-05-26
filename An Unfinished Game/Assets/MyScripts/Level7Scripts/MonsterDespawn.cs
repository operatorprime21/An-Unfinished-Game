using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDespawn : MonoBehaviour
{
    //As mentioned in another script this was supposed to play in an event where the player closes the door, destroying the monster instance so it would not touch a new object that spawns another monster.
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
            Debug.Log("!!!");
        }
    }
}