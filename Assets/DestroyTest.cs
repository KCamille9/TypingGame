using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);

        //Collider myCollider = collision.contactOffset[0];

        Destroy(collision.gameObject);

    }
}
