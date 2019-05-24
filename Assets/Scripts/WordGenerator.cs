using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{

    //Note: Make sure te words don't have any whitespaces on them

    /*private static string[] wordList = { "Você", "vai", "sentar", "por", "cima", "E", "o", "DJ", "vai", "te", "pegar",
        "Tu", "pediu", "agora", "toma", "Não", "adianta", "tu", "voltar", "Menina", "Agora", "você", "vai", "sentar",
        "Dou", "tapinha", "na", "potranca", "Com", "o", "bumbum", "ela", "balança", "Se", "eu", "te", "chamo", "de",
        "malandra", "Você", "vai", "se", "apaixonar", "Dou", "tapinha", "na", "potranca", "Com", "o", "bumbum", "ela", "balança",
        "Se", "eu", "te", "chamo", "de", "malandra", "Você", "vai", "se", "apaixonar", "Ah", "ah", "aaaaaah", "Agora",
        "vai", "sentar!", "Vai", "sentar!", "Vai", "sentar!", "Vai", "sentar!", "Vai", "sentar!"
    };*/

    private static string[] wordArr;
    private static List<string> wordList2 = new List<string>();

    private static int index = 0;

    private void Start()
    {
        string path = @"D:\Unity Projects\FUNK GAME Project notes and Ideas\FunkSongs\agoraVaiSentar.txt";
        wordArr = File.ReadAllLines(path);
        foreach(string word in wordArr)
        {
            wordList2.Add(word);
        }
    }




    public static string GetFunkWord()
    {
        string randomWord;//The variable name is wrong, potranca. You should change that, novinha.

        if (index == wordList.Length)
        {
            index = 0;
        }

        Debug.Log(wordList2[5]);

        randomWord = wordList2[1];
        
        index++;

        return randomWord;
        

    }
}
