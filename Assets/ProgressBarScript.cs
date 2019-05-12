using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarScript : MonoBehaviour
{
    public Slider slider;

    public float wordDelay = 1.5f;
    private float nextWordTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextWordTime) //this time at the beginning of the game
        {
            slider.value += 0.02f;
            nextWordTime = Time.time + wordDelay;
            wordDelay *= .99f; //reduces the total amount of time
        }
        
    }
}
