using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPipe : MonoBehaviour
{
    public Collider m_ObjectCollider;

    //This drop event was planned to be much more prevalent in the game but due to how jank the physics system is, it only shows up twice
    //This script handles the interaction of hitting the loose pipe with something to make it drop creating a path
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "stick")
        {
            m_ObjectCollider.isTrigger = false;
            Debug.Log("boom");
        }
    }
}
