using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaScript : MonoBehaviour
{
    public bool Sea = false;
    void OnCollisionEnter(Collision ObjectColliedWith)
    {
        if (ObjectColliedWith.collider.tag == "SeaItem")
        {
            Sea = true;
            Debug.Log("Sea");
        }
    }
    void OnCollisionExit(Collision ObjectColliedWith)
    {
        if (ObjectColliedWith.collider.tag == "SeaItem")
        {
            Sea = false;
        }
    }
}
