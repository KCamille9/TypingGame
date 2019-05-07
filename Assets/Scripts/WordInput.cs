using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour
{
    public WordManager wordManager;

    // Update is called once per frame
    void Update()
    {
        foreach (char letter in Input.inputString)
        { // get user input per frame

            /*foreach(Word word in wordManager.words)
            {
                if (!word.InsideBoundaries())
                {
                    wordManager.words.Remove(word);
                    Debug.Log(word);
                }
            }*/
       
            wordManager.TypeLetter(letter);
        }
    }
}
