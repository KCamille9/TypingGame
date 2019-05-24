﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("BkgMusic");
        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
