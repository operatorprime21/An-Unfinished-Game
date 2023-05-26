using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    public bool Star = false;
    void OnCollisionEnter(Collision ObjectColliedWith)
    {
        if (ObjectColliedWith.collider.tag == "StarItem")
        {
            Star = true;
            Debug.Log("Star");
        }
    }
    void OnCollisionExit(Collision ObjectColliedWith)
    {
        if (ObjectColliedWith.collider.tag == "StarItem")
        {
            Star = false;  
        }
    }
         
   
}
