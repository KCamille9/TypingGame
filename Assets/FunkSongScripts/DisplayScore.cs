using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public GameObject TextObj;
    float TmStart;
    float TmLen = 1f;

    // Use this for initialization
    void Start()
    {
        TmStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > TmStart + TmLen)
        {
           // Debug.Log("oiiii");
            TextObj.SetActive(true);
        }
    }


}
