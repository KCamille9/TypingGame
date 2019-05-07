using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour
{
    public Text text;
    public float fallSpeed = 1; //u can also make this random

    public void SetWord (string word)
    {
        text.text = word;
        text.color = Color.magenta;
        //text.verticalOverflow = true;
        text.fontSize = 25;
    }

    public void RemoveLetter()
    {
        text.text = text.text.Remove(0, 1); //ONLY REMOVE FIRST LETTER
        text.color = Color.cyan;
    }

    public void RemoveWord()
    {
        Destroy(gameObject);
       // Debug.Log(fallSpeed);
    }

    public void SetFallSpeed(float newFallSpeed)
    {
        fallSpeed = newFallSpeed;
    }

    private void Update()
    {
        transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f); // move word along y axis
        

    }
}
