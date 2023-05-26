using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ExitButton : MonoBehaviour
{
    //Need to exist separatedly from other buttons since pause and death screen both has it
    public void TaskOnClick()
    {
        Application.Quit();
    }
}
