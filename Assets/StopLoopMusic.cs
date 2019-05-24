using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLoopMusic : MonoBehaviour
{
    void Awake()
    {
        GameObject A = GameObject.FindGameObjectWithTag("BkgMusic");
        Destroy(A);
        //you're welcome
    }
}
