using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WordTimer : MonoBehaviour
{
    public WordManager wordManager;

    public float wordDelay = 1.5f;
    private float nextWordTime = 0f;

    public AudioSource songClip;

    public GameObject endTitle;


    private void Update()
    {
        float song25Per = songClip.clip.length / 4;
        float song50Per = songClip.clip.length / 2;
        float song75Per = song25Per + song50Per;

        if(Time.time > songClip.clip.length -1 && Time.time < songClip.clip.length)
        {
            endTitle.gameObject.SetActive(true);
        }

        if(Time.time > song25Per - 1 && Time.time < song25Per)
        {
            wordDelay = 1.3f;
        }

        if (Time.time > song50Per - 1 && Time.time < song50Per)
        {
            wordDelay = 1.1f;
        }

        if (Time.time > song75Per - 1 && Time.time < song75Per)
        {
            wordDelay = 0.9f;
        }

        if (Time.time >= nextWordTime)
        {

            wordManager.AddWord();
            nextWordTime = Time.time + wordDelay;
            //wordDelay *= .99f;
            Debug.Log("time.time is: " + Time.time + ", and nextwordtime is:  " + wordDelay);
           // Debug.Log(songClip.clip.length);
        }
    }
}
