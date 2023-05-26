using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3Drops : MonoBehaviour
{
    public Rigidbody DropPipe;
    //This script handles giving the Pipe gravity and physics (since it hangs without physics mid-air before) after colliding
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DropPipe")
        {
            Debug.Log("thud");
            other.attachedRigidbody.useGravity = true;
        }
    }
}
