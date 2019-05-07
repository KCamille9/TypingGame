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

    public WordSpanner wordSpawner;

    private bool hasActiveWord;
    private Word activeWord;

    private float testSpeed = 1; //make this priuvate for some reason



    //Audio clapping audio
    public AudioSource musicSource;


    public void Start()
    {
        musicSource = GetComponent<AudioSource>();
    }




    private int destroyCount;

    public void AddWord()
    {
        String funkWord = WordGenerator.GetFunkWord(); //getting random word
        WordDisplay funkWordDisplay = wordSpawner.SpawnWord(); //getting word diplay from wordSpanner



        Word word = new Word(funkWord, funkWordDisplay); //creating new word

        wordSpawner.SetObjectName(word); //setting word string to newly created gameobject


        //modyfing new word Speed
        word.GetWordDisplay().SetFallSpeed(testSpeed);
        //Debug.Log(word.GetWordDisplay().fallSpeed);


        //Cleansing word string
        funkWord = funkWord.ToLower(); //lowercasing;

        var finalFunkWord = funkWord;

        if(funkWord.Contains("ç") || funkWord.Contains("ê") || funkWord.Contains("â") || funkWord.Contains("ô") ||
            funkWord.Contains("ã") || funkWord.Contains("õ") || funkWord.Contains("à") || funkWord.Contains("á") ||
            funkWord.Contains("é") || funkWord.Contains("í") || funkWord.Contains("ó") || funkWord.Contains("ú")
            ){

            //Normalizing Portuguese words to English equivalent
            var normalFunkWord = funkWord.Normalize(NormalizationForm.FormD);
            var filtered = normalFunkWord.Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark);
            finalFunkWord = new String(filtered.ToArray());
        }

        funkWord = finalFunkWord;

        //Adding final word to Words list
        word.SetWordString(funkWord); 
        words.Add(word);
    }

    public void NormalizeWord(Word portugueseWord)
    {
        //modyfing new word Speed
        Word normalizedWord = portugueseWord;

        //Set test speed to modify later
        normalizedWord.GetWordDisplay().SetFallSpeed(testSpeed);
        //Debug.Log(normalizedWord.GetWordDisplay().fallSpeed);


        //Cleansing word string
        string lowercasedWordStr = normalizedWord.GetWordString().ToLower(); //lowercasing;

        var finalFunkWord = lowercasedWordStr;

        if (finalFunkWord.Contains("ç") || finalFunkWord.Contains("ê") || finalFunkWord.Contains("â") || finalFunkWord.Contains("ô") ||
            finalFunkWord.Contains("ã") || finalFunkWord.Contains("õ") || finalFunkWord.Contains("à") || finalFunkWord.Contains("á") ||
            finalFunkWord.Contains("é") || finalFunkWord.Contains("í") || finalFunkWord.Contains("ó") || finalFunkWord.Contains("ú")
            )
        {
            //Normalizing Portuguese words to English equivalent
            var normalFunkWord = finalFunkWord.Normalize(NormalizationForm.FormD);
            var filtered = normalFunkWord.Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark);
            finalFunkWord = new String(filtered.ToArray());
        }

        normalizedWord.SetWordString(finalFunkWord);
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

    public bool WordInList(List<Word> list, string wordStr)
    {
        bool wordInList = false;

        Word wordCheck = FindWordInList(wordStr);

        if(wordCheck != null)
        {
            wordInList = true;
        }

        return wordInList;
    }


    public void TypeLetter (char letter)
    {

        if (hasActiveWord)
        {
            //check if letter was next
            //remove it from the word
            if(activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }

            //si la palabra gameobject se destruyo (alcanzo el borde de la pantalla)
            //hasActiveWord = false;

        }
        else
        {
            foreach(Word w in words)
            {
                if (w.GetNextLetter() == letter) //searching which word in the list the user is typing
                {
                    activeWord = w; //activating which word is user typing
                    hasActiveWord = true;
                    w.TypeLetter();
                    break; //we found letter, stop
                }

                hasActiveWord = false;
            }
        }

        if(hasActiveWord && activeWord.WordTyped())
        {
            if (destroyCount == 5)
            {
                testSpeed += 1;
                destroyCount = 0;

                //clapping audio
                musicSource.Play();

            }

             hasActiveWord = false;
             words.Remove(activeWord);
             destroyCount++;


            // Default folder  
             string rootFolder = @"D:\Unity Projects\FunkSongs\";
            //Default file  
            /* string textFile = @"D:\Unity Projects\FunkSongs\elaquica.txt";


            string[] lines = File.ReadAllLines(textFile);

            foreach (string line in lines)
                Debug.Log(line);*/


            /*Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

            if (pos.y < 0.0)
                Debug.Log("I am left of the camera's view.");


            Vector2 screenSize;

            Vector3 cameraPos = Camera.main.transform.position;
            screenSize.x = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f; //Grab the world-space position values of the start and end positions of the screen, then calculate the distance between them and store it as half, since we only need half that value for distance away from the camera to the edge
            screenSize.y = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;


            Debug.Log(screenSize.x);




            Debug.Log(testSpeed);*/

        }

    }
}
