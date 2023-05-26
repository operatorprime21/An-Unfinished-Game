using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchTrap : MonoBehaviour
{
    public GameObject trap;
    public GameObject seaItem;
    //Jumpscare attempt? Just having fun rather with things that can be done, especially if they serve some level of contextualizing events
    void OnCollisionEnter(Collision ObjectCollidedWith)
    {
        if (ObjectCollidedWith.collider.tag == "SeaItem")
        {
            Debug.Log("Sea");
        }
        Destroy(gameObject);
        Debug.Log("!");
        Instantiate(trap, this.transform.position, this.transform.rotation);
        seaItem.GetComponent<Rigidbody>().useGravity = true;
    }
     
}
