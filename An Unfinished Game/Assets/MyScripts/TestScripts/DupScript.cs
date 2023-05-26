using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DupScript : MonoBehaviour
{
    public Rigidbody Box;

    // Start is called before the first frame update
    void OnCollisionEnter (Collision ObjectCollidedWith)
    {
        Debug.Log("Touched " + ObjectCollidedWith.collider.tag);
        Rigidbody duppedBox = Instantiate(Box, new Vector3(this.transform.position.x + 5, this.transform.position.y, this.transform.position.z), this.transform.rotation);
    }
}
