using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiateList : MonoBehaviour
{

    public static List<String> wordList = new List<String>(); //instatiate 'cuz if not a null reference occurs

    private static int index = 0;



    void Start()
    {
        Debug.Log("holaaaa");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
