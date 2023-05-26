using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloning : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody redKey;
    public Rigidbody blueKey;
    public Rigidbody yellowKey;
    public Rigidbody purpleKey;
    public Rigidbody greenKey;
    public Rigidbody teleporter;
    bool triggerIsDisabled = false;
    

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "RedKey" && triggerIsDisabled == false)
        {
            StartCoroutine(CollideDelay());
            StartCoroutine(RedKeyClone());
        }   
        else if (other.gameObject.tag == "BlueKey" && triggerIsDisabled == false)
        {
            StartCoroutine(CollideDelay());
            StartCoroutine(BlueKeyClone());
        }
        else if (other.gameObject.tag == "YellowKey" && triggerIsDisabled == false)
        {
            StartCoroutine(CollideDelay());
            StartCoroutine(YellowKeyClone());
        }
        else if (other.gameObject.tag == "PurpleKey" && triggerIsDisabled == false)
        {
            StartCoroutine(CollideDelay());
            StartCoroutine(PurpleKeyClone());
        }
        else if (other.gameObject.tag == "GreenKey" && triggerIsDisabled == false)
        {
            StartCoroutine(CollideDelay());
            StartCoroutine(GreenKeyClone());
        }
        else if (other.gameObject.tag == "Teleporter" && triggerIsDisabled == false)
        {
            StartCoroutine(CollideDelay());
            StartCoroutine(TeleporterClone());
            Debug.Log("tele");
        }
    }

    IEnumerator RedKeyClone()
    {
        yield return new WaitForSeconds(5f);
        Rigidbody CloneRedKey = Instantiate(redKey, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 8), this.transform.rotation);
    }
    IEnumerator BlueKeyClone()
    {
        yield return new WaitForSeconds(5f);
        Rigidbody CloneBlueKey = Instantiate(blueKey, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 8), this.transform.rotation);
    }
    IEnumerator YellowKeyClone()
    {
        yield return new WaitForSeconds(5f);
        Rigidbody CloneYellowKey = Instantiate(yellowKey, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 8), this.transform.rotation);
    }
    IEnumerator PurpleKeyClone()
    {
        yield return new WaitForSeconds(5f);
        Rigidbody ClonePurpleKey = Instantiate(purpleKey, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 8), this.transform.rotation);
    }
    IEnumerator GreenKeyClone()
    {
        yield return new WaitForSeconds(5f);
        Rigidbody CloneGreenKey = Instantiate(greenKey, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 8), this.transform.rotation);
    }
    IEnumerator TeleporterClone()
    {
        yield return new WaitForSeconds(5f);
        Rigidbody CloneTeleporter = Instantiate(teleporter, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 8), this.transform.rotation);
    }


    IEnumerator CollideDelay()
    {
        triggerIsDisabled = true;

        yield return new WaitForSeconds(10f);
        triggerIsDisabled = false;
    }
}
