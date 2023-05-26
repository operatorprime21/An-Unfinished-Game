using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataDestroy : MonoBehaviour
{
    //Part of the cool "green data transfer animation"
    void Start()
    {
        Destroy(gameObject, 0.2f);
    }

}
