using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSfx : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;


    public void HoverSound()
    {

    }

    public void ClickSound()
    {
        myFx.PlayOneShot(clickFx);
    }
}
