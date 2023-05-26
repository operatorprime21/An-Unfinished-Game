using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTheme : MonoBehaviour
{
    public AudioClip menuTheme;
    
    void Start()
    {
        AudioSource.PlayClipAtPoint(menuTheme, this.transform.position);
    }

}
