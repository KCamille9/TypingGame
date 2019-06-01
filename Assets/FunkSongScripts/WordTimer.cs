using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WordTimer : MonoBehaviour
{
    public WordManager wordManager;

    public float wordDelay = 1.5f;
    private float nextWordTime = 0f;

    private float secondWordDel;
    private float thirdWordDel;
    private float fourthWordDel;

    public AudioSource songClip;

    public GameObject endPanel;
    public GameObject mainCanvas;


    private void Start()
    {
        secondWordDel = wordDelay - 0.2f;
        thirdWordDel = wordDelay - 0.4f;
        fourthWordDel = wordDelay - 0.6f;
    }


    private void Update()
    {
        var currenttTime = Time.time;

        float song25Per = songClip.clip.length / 4;
        float song50Per = songClip.clip.length / 2;
        float song75Per = song25Per + song50Per;

        float secWordDel = wordDelay - 0.2f;

        //Display EndPanel when song ends
        if(currenttTime > songClip.clip.length - 1 && currenttTime < songClip.clip.length)
        {
            Debug.Log("words should not be added");
            endPanel.gameObject.SetActive(true);
            mainCanvas.gameObject.SetActive(false);

        }
        else
        {
            //Decrease word delay when song is at 25%
            if (currenttTime > song25Per - 1 && currenttTime < song25Per)
            {
                Debug.Log("first time");
                wordDelay = secondWordDel;
            }

            //Decrease word delay when song is at 50%
            if (currenttTime > song50Per - 1 && currenttTime < song50Per)
            {
                Debug.Log("second time");
                wordDelay = thirdWordDel;
            }

            //Decrease word delay when song is at 75%
            if (currenttTime > song75Per - 1 && currenttTime < song75Per)
            {
                Debug.Log("third time");
                wordDelay = fourthWordDel;
            }

            if (currenttTime >= nextWordTime)
            {
                wordManager.AddWord();
                nextWordTime = Time.time + wordDelay;
            }
        }

        
    }
}
