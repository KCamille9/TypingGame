using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Word> words;
    public int wordIndex = 0;

    public WordSpanner wordSpawner;

    private bool hasActiveWord;
    private Word activeWord;

    private float testSpeed = 1; //make this priuvate for some reason

    private int destroyCount;

    //Audio clapping audio
    public AudioSource musicSource;


    public void Start()
    {
        musicSource = GetComponent<AudioSource>();
    }


    public void AddWord()
    {
        String funkWord = WordGenerator.GetFunkWord(); //getting random word
        WordDisplay funkWordDisplay = wordSpawner.SpawnWord(); //getting word diplay from wordSpanner
        Word word = new Word(wordIndex, funkWord, funkWordDisplay, false); //creating new word

        word.GetWordDisplay().SetFallSpeed(testSpeed); //modyfing new word Speed
        wordSpawner.SetObjectName(word); //setting word string to newly created gameobject

        words.Add(word);

        wordIndex++; //increase index

    }


    public List<Word> GetList()
    {
        return this.words;
    }

    public Word FindWordInList(string wordStr)
    {
        Word foundWord = null;

        foreach (Word word in words)
        {
            if (word.GetWordString().Equals(wordStr))
            {
                foundWord = word;
            }
        }

        return foundWord;
    }

    public bool WordInList(Word wordStr)
    {
        bool wordInList = false;

        //COMPARE SOMETHING ELSE THAN STRINGSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS

        foreach (Word word in words)
        {
            //if (word.GetWordString().Equals(wordStr.GetWordString()) && word.index == wordStr.index)
            if (word.index == wordStr.index)
            {
                wordInList = true;
                break;
            }
        }

        Debug.Log("condicion de typeletter: " + wordInList);
        Debug.Log("Word index: " + wordStr.index);


        return wordInList;
    }


    public void TypeLetter (char letter)
    {

        //si la palabra gameobject se destruyo (alcanzo el borde de la pantalla)
        if (hasActiveWord && WordInList(activeWord))
        {       

            //check if typed letter was next, remove it from word.
            if (activeWord.GetNextLetter() == letter)
            {
               activeWord.TypeLetter();
            }
            
        }
        else
        {

            foreach(Word w in words)
            {
                if (w.GetNextLetter() == letter) //searching which word in the list the user is typing
                {
                    activeWord = w; //activating which word is user typing
                    LastWordScript.lastWord = activeWord.word; //For debugging
                    LastIndexScript.lastIndex = activeWord.GetTypeIndex(); //For debugging

                    hasActiveWord = true;
                    w.TypeLetter();
                    break; //we found letter, stop
                }

                hasActiveWord = false;
            }
        }

        if(hasActiveWord && activeWord.WordTyped())
        {
            /* if (destroyCount == 5)
             {

                 //el isOnscreen esta un poco mas bajo que el camara top y
                 /*foreach(Word w in words)
                 {
                     if(w.isOnScreen == true)
                     {
                         testSpeed += 1;
                         w.GetWordDisplay().SetFallSpeed(testSpeed);
                     }

                 }

                 testSpeed += 1;
                 destroyCount = 0;

                 //clapping audio
                 musicSource.Play();

             }*/

             hasActiveWord = false;
             words.Remove(activeWord);
             destroyCount++;
            ScoreScript.scoreValue += 5;

        }

    }
}
