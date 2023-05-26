using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySphere : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody Orb;
    public GameObject OrbClone;
    void Start()
    {
        Destroy(Orb, 1f);
        Destroy(OrbClone, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
