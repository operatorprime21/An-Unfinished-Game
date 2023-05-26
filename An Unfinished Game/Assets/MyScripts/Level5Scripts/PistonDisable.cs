using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonDisable : MonoBehaviour
{
    public SeaScript sea;
    public StarScript star;
    public MoonScript moon;
    public GameObject piston1;
    public GameObject piston2;
    public GameObject piston3;
    public GameObject piston4;
    public GameObject piston5;
    public GameObject piston6;
    
    //Controls the solution of the puzzle, making sure the player gets the EXACT solution
    
    void Update()
    {
        if (star.Star == true && moon.Moon == true && sea.Sea == true)
        {
            piston1.GetComponent<PistonBhvr>().enabled = false;
            piston1.GetComponent<PistonEnd>().enabled = true;

            piston2.GetComponent<PistonBhvr2>().enabled = false;
            piston2.GetComponent<PistonEnd2>().enabled = true;

            piston3.GetComponent<PistonBhvr>().enabled = false;
            piston3.GetComponent<PistonEnd>().enabled = true;

            piston4.GetComponent<PistonBhvr2>().enabled = false;
            piston4.GetComponent<PistonEnd2>().enabled = true;

            piston5.GetComponent<PistonBhvr>().enabled = false;
            piston5.GetComponent<PistonEnd>().enabled = true;

            piston6.GetComponent<PistonBhvr2>().enabled = false;
            piston6.GetComponent<PistonEnd2>().enabled = true;
        }
    }
}
