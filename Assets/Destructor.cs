using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        float bulletLife = 5.0f;
        Destroy(other.gameObject, bulletLife);
        Destroy(GameObject.Find(other.name + "(Clone)"));
        Debug.Log("I destroyed something!");
    }
}
