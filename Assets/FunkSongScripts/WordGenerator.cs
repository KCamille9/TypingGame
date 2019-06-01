using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{

    //Note: Make sure te words don't have any whitespaces on them

    public static List<String> wordList = new List<String>(); //instatiate 'cuz if not a null reference occurs

    private static int index = 0;

    public TextAsset funkSong;

    private void Start()
    {

        //string path = @"D:\Unity Projects\FUNK GAME Project notes and Ideas\FunkSongs\agoraVaiSentar.txt";
        string path = "Assets/Songs Texts/" + funkSong.name + ".txt";

        string[] lines = File.ReadAllLines(path, System.Text.Encoding.UTF8); //Encoding UTF8 so that it can recognize special symbolsS


        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            line = NormalizeWord(line);
            lines[i] = line;  //assign back to the list

        }

        foreach (string line in lines)
        {
            wordList.Add(line);
        }

        
    }

    public static string NormalizeWord(string portugueseWord)
    {
        String finalWord2 = portugueseWord.ToLower();

        var finalWord = finalWord2;

        //Cleansing word string
        if (finalWord.Contains("ç") || finalWord.Contains("ê") || finalWord.Contains("â") || finalWord.Contains("ô") ||
            finalWord.Contains("ã") || finalWord.Contains("õ") || finalWord.Contains("à") || finalWord.Contains("á") ||
            finalWord.Contains("é") || finalWord.Contains("í") || finalWord.Contains("ó") || finalWord.Contains("ú")
            )
        {
            //Normalizing Portuguese words to English equivalent
            var normalWord = finalWord.Normalize(NormalizationForm.FormD);
            var filtered = normalWord.Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark);
            finalWord = new String(filtered.ToArray());
        }

        String fw = finalWord;

        return fw;
    }



    public static string GetFunkWord()
    {
        //string randomWord;//The variable name is wrong, potranca. You should change that, novinha.

        string songWord;

        if (index == wordList.Count)
        {
            Debug.Log("reached the end of the text file");
            index = 0;
        }

        songWord = wordList[index];
        
        index++;

        return songWord;
    }
}
