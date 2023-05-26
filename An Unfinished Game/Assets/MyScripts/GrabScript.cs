using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform grab;
    public float projectileSpeed = 500f;
    private RaycastHit hit;
    private GameObject GrabBox;
    private bool objectMidFlight;
    public Transform Player;
    public Transform rb;
    

    public void Start()
    {
        //Highly important script used to grab objects, throw and wrap. Script exists in an empty object that sits just in front of the camera, said object hosts the new transform component of the physics object.
    }
    public void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(grab.position, grab.forward, out hit, 5) && hit.transform.GetComponent<Rigidbody>())
        {
            GrabBox = hit.transform.gameObject;
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            GrabBox = null;
            //letting go of object by nullifying the empty gameobject that hosts the transform position of the held object
        }
        if (objectMidFlight == true && Input.GetKeyDown(KeyCode.E))
        {
            CharacterController cc = Player.GetComponent<CharacterController>();
            cc.enabled = false;
            Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
            Player.position = rb.transform.position;
            Debug.Log("E pressed");
            cc.enabled = true;
            objectMidFlight = false;
            Debug.Log("Object inactive");
            //Wrap using teleporter action
        }
    }

    public void FixedUpdate()
    {
        if (GrabBox)
        {
            Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
            rb.rotation = gameObject.transform.rotation;
            rb.velocity = 5 * (grab.position - GrabBox.transform.position);
            if (Input.GetMouseButton(1))
            {
                GrabBox = null;
                rb.AddRelativeForce(Vector3.forward * projectileSpeed);
                StartCoroutine(ObjectFlying());
                //Throw action. 
            }
        }
    }
    IEnumerator ObjectFlying()
    {
        objectMidFlight = true;
        Debug.Log("Object active");
        yield return new WaitForSeconds(3f);
        objectMidFlight = false;
        Debug.Log("Object inactive");
        //Describes the time frame when the "Teleporter" object is ready wrap. 
    }
}
