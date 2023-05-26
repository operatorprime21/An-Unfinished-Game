using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverRigid : MonoBehaviour
{
    public GameObject cursor;
    public Transform player;
    public GameObject guide;
    // Start is called before the first frame update
    void OnMouseOver()
    {
        if (Vector3.Distance(player.position, transform.position) <= 7f)
        {
            cursor.SetActive(true);
            guide.SetActive(true);
            
        }
    }

    // Update is called once per frame
    void OnMouseExit()
    {
        cursor.SetActive(false);
        guide.SetActive(false);
        
    }
    //Script made to make sure the cursor tells the player what does or doesn't have physics to be picked up by changing color.
    //Technical wise, its simply overlaying the white curser with a green one.
}
