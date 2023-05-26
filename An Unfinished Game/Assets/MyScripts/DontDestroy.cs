using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        //Back up. In case something needs to last through levels that was not thought needed before.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
