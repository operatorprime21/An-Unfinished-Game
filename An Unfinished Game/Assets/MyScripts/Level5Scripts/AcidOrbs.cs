using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidOrbs : MonoBehaviour
{
    // Fix to avoid overloading scene with balls.
    void Start()
    {
        Destroy(gameObject, 3f);
    }

}
