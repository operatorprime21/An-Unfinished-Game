using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankDestroy : MonoBehaviour
{
    private int plankHealth = 3;
    
    public Rigidbody planks;
    private void Start()
    {
        planks.isKinematic = true;
    }
    // Simulate hitting a plank to make them fall when hit enough times
    private void OnCollisionEnter(Collision ObjectCollidedWith)
    {
                plankHealth = plankHealth - 1;
                Debug.Log(gameObject + " hit. Health left: " + plankHealth);
                if (plankHealth == 0)
                {
                     planks.isKinematic = false;
                }
    }
}
