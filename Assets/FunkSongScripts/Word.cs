using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public int index;
    public string word;
    WordDisplay display;
    public bool isOnScreen;

    private int typeIndex;

    public Word(int _index, string _word, WordDisplay _display, bool _isOnScreen)
    {
        index = _index;
        typeIndex = 0;

        word = _word;

        display = _display;
        display.SetWord(word);

        isOnScreen = _isOnScreen;
    }

    public void SetToOnScreen()
    {
        this.isOnScreen = true;
    }

    public WordDisplay GetWordDisplay()
    {
        return this.display;
    }

    public string GetWordString()
    {
        return this.word;
    }

    public int GetTypeIndex()
    {
        return this.typeIndex;
    }

    public void SetWordString(string newWord)
    {
        word = newWord;
    }

    public char GetNextLetter()
    {
       // Debug.Log(typeIndex);
       // Debug.Log(word[typeIndex]);
        return word[typeIndex];
    }

    public void TypeLetter()
    {
        //only if is right
        //Debug.Log(typeIndex);
        
        display.RemoveLetter(); //remove letter from screen

        LastLetterScript.lastLetter = word[typeIndex];
        LastIndexScript.lastIndex = typeIndex;

        typeIndex++;
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

}
