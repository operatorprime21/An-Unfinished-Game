using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transfer : MonoBehaviour
{
    public float projSpeed;
    public Rigidbody data;
    public float fireRate;
    List<Rigidbody> dataList = new List<Rigidbody>();
    
    void OnEnable()
    {
        StartCoroutine(dataTransfer());
    }
    //The specifics of the green data transfer animation of the dup machine. In reality its just a very small, shortlived version of the projectile dispenser.
    IEnumerator dataTransfer()
    {
        for (int n = 0; n < 10; n++)
        {
            Rigidbody newProj = Instantiate(data, this.transform.position, this.transform.rotation);
            newProj.AddRelativeForce(Vector3.forward * projSpeed);
            dataList.Add(newProj);
            yield return new WaitForSeconds(fireRate);
            n = n - 1;
        }
    }
}

