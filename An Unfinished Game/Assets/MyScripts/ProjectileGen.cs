using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGen : MonoBehaviour
{
    public float projSpeed;
    public Rigidbody Orb;
    public float fireRate;
    public AudioClip acid;
    List<Rigidbody> projList = new List<Rigidbody>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(orbGen());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator orbGen()
    {
        for (int n = 0; n < 10; n++)
        {
            //Simulates a continuous dispenser that ejects projectiles by using a loop that never ends. 
            AudioSource.PlayClipAtPoint(acid, this.transform.position);
            Rigidbody newProj = Instantiate(Orb, this.transform.position, this.transform.rotation);
            newProj.AddRelativeForce(Vector3.forward * projSpeed);
            projList.Add(newProj);
            yield return new WaitForSeconds(fireRate);
            n = n - 1;
        }
    }
}
