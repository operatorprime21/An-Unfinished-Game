using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonScript : MonoBehaviour
{
    
    public bool Moon = false;
    void OnCollisionEnter(Collision ObjectColliedWith)
    {
        if (ObjectColliedWith.collider.tag == "MoonItem")
        {
            Moon = true;
            Debug.Log("Moon");
        }
    }
    void OnCollisionExit(Collision ObjectColliedWith)
    {
        if (ObjectColliedWith.collider.tag == "MoonItem")
        {
            Moon = false;
        }
    }
}
