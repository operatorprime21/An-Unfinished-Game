using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterFix : MonoBehaviour
{
    public GameObject Player;
   //Fix for collision between the Teleporter and the player that can cause it to bounce off the player. This was needed to make level 6 winable.
    void Start()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), Player.GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
