using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverMove : MonoBehaviour
{
    public GameObject coverUpper;
    public GameObject coverLower;
    public Transform coverUp;
    public Transform coverLow;
    bool triggerIsDisabled = false;
    public AudioClip cover;
    //Once again using Lerp to animate the duplicating machine's animations.

    void OnCollisionEnter(Collision ObjectCollidedWith)
    {
        if (triggerIsDisabled == false)
        {
            StartCoroutine(UpperMove(coverUpper, new Vector3(coverUpper.transform.position.x, coverUp.transform.position.y - 2, coverUpper.transform.position.z), 5f));
            StartCoroutine(LowerMove(coverLower, new Vector3(coverLower.transform.position.x, coverLow.transform.position.y + 2, coverLower.transform.position.z), 5f));
            StartCoroutine(UpperMoveUp(coverUpper, new Vector3(coverUpper.transform.position.x, coverUp.transform.position.y, coverUpper.transform.position.z), 5f));
            StartCoroutine(LowerMoveDown(coverLower, new Vector3(coverLower.transform.position.x, coverLow.transform.position.y, coverLower.transform.position.z), 5f));
            StartCoroutine(CollideDelay());
        }
    }

    IEnumerator UpperMov (GameObject coverUpper, Vector3 end, float speed)
    {
        coverUpper.transform.position = Vector3.MoveTowards(coverUpper.transform.position, end, 100f * Time.deltaTime);
        yield return new WaitForEndOfFrame();
    }
    IEnumerator LowerMov (GameObject coverLower, Vector3 end, float speed)
    {
        coverLower.transform.position = Vector3.MoveTowards(coverLower.transform.position, end, 100f * Time.deltaTime);
        yield return new WaitForEndOfFrame();
    }

    IEnumerator UpperMove    (GameObject coverUpper, Vector3 end, float seconds)
    {
        AudioSource.PlayClipAtPoint(cover, this.transform.position);
        float doorMoveTime = 0f;
        while (doorMoveTime <= seconds)
        {
            coverUpper.transform.position = Vector3.Lerp(coverUpper.transform.position, end, (doorMoveTime / 1000f));
            doorMoveTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        coverUpper.transform.position = end;
    }

    IEnumerator LowerMove    (GameObject coverLower, Vector3 end, float seconds)
    {
        AudioSource.PlayClipAtPoint(cover, this.transform.position);
        float doorMoveTime = 0f;
       while (doorMoveTime <= seconds)
       {
           coverLower.transform.position = Vector3.Lerp(coverLower.transform.position, end, (doorMoveTime / 1000f));
           doorMoveTime += Time.deltaTime;
          yield return new WaitForEndOfFrame();
       }
       coverLower.transform.position = end;
    }

    IEnumerator UpperMoveUp(GameObject coverUpper, Vector3 end, float seconds)
    {
        yield return new WaitForSeconds(10f);
        AudioSource.PlayClipAtPoint(cover, this.transform.position);
        float doorMoveTime = 0f;
        while (doorMoveTime <= seconds)
        {
            coverUpper.transform.position = Vector3.Lerp(coverUpper.transform.position, end, (doorMoveTime / 1000f));
            doorMoveTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        coverUpper.transform.position = end;
    }

    IEnumerator LowerMoveDown(GameObject coverLower, Vector3 end, float seconds)
    {
        yield return new WaitForSeconds(10f);
        AudioSource.PlayClipAtPoint(cover, this.transform.position);
        float doorMoveTime = 0f;
        while (doorMoveTime <= seconds)
        {
            coverLower.transform.position = Vector3.Lerp(coverLower.transform.position, end, (doorMoveTime / 1000f));
            doorMoveTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        coverLower.transform.position = end;
    }
    IEnumerator CollideDelay()
    {
        triggerIsDisabled = true;
        yield return new WaitForSeconds(10f);
        triggerIsDisabled = false;
    }
}

