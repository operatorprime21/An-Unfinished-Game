using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    public float projSpeed;
    public Rigidbody Orb;
    public float fireRate;
    List<Rigidbody> projList = new List<Rigidbody>();
    // A second version of the hazardous projectile dispenser.
    void Start()
    {
        StartCoroutine(orbGen());
    }
    IEnumerator orbGen()
    {
        for (int n = 0; n < 10; n++)
        {
            Rigidbody newProj = Instantiate(Orb, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z +1f), this.transform.rotation);
            newProj.AddRelativeForce(Vector3.forward * projSpeed);
            projList.Add(newProj);
            yield return new WaitForSeconds(fireRate);
            n = n - 1;
        }
    }
}