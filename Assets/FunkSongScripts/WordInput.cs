using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour
{
    public WordManager wordManager;

    // Update is called once per frame
    void Update()
    {
        foreach (char letter in Input.inputString) // get user input per frame
        { 

            /*foreach(Word word in wordManager.words)
            {
                if (!wordManager.WordInList(word))
                {
                    wordManager.words.Remove(word);
                    Debug.Log("this worked?");
                }
            }*/
       
            wordManager.TypeLetter(letter);
        }
    }
}
