using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Song : MonoBehaviour
{
    public string word;

    private int typeIndex;

    public bool isOnScreen;

    WordDisplay display;

    public Song(string _word, WordDisplay _display, bool _isOnScreen)
    {
        word = _word;
        typeIndex = 0;
        isOnScreen = _isOnScreen;

        display = _display;
        display.SetWord(word);
    }

    public WordDisplay GetWordDisplay()
    {
        return this.display;
    }

    public string GetWordString()
    {
        return this.word;
    }

    public void SetWordString(string newWord)
    {
        word = newWord;
    }

    public char GetNextLetter()
    {
        return word[typeIndex];
    }

    public void TypeLetter()
    {
        typeIndex++;
        display.RemoveLetter(); //remove letter from screen
    }

    public bool WordTyped()
    {
        bool wordTyped = (typeIndex >= word.Length);
        if (wordTyped)
        {
            //Remove word from screen
            display.RemoveWord();

        }
        return wordTyped;
    }

    /* public bool InsideBoundaries()
     {

         //Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

         Vector3 tempos = transform.position;

         if (tempos != null &&  tempos.y >= 0.0){
             Debug.Log("it's working");

             return false;
         }

         return true;
     }*/

}
