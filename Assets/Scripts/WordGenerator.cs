using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{

    //Note: Make sure te words don't have any whitespaces on them

  private static string[] wordList = { "Você", "vai", "sentar", "por", "cima", "E", "o", "DJ", "vai", "te", "pegar",
        "Tu", "pediu", "agora", "toma", "Não", "adianta", "tu", "voltar", "Menina", "Agora", "você", "vai", "sentar",
        "Dou", "tapinha", "na", "potranca", "Com", "o", "bumbum", "ela", "balança", "Se", "eu", "te", "chamo", "de",
        "malandra", "Você", "vai", "se", "apaixonar", "Dou", "tapinha", "na", "potranca", "Com", "o", "bumbum", "ela", "balança",
        "Se", "eu", "te", "chamo", "de", "malandra", "Você", "vai", "se", "apaixonar", "Ah", "ah", "aaaaaah", "Agora",
        "vai", "sentar!", "Vai", "sentar!", "Vai", "sentar!", "Vai", "sentar!", "Vai", "sentar!"
    };


    /* private static string[] wordList = {"chuchuruchu", "chuchuruchuuuu", "nananaaa", "balança", "Voce", "vai", "sentar", "por", "cima", "E", "o", "DJ", "vai", "te", "pegar",
         "tu", "pediu", "agora", "toma", "nao", "adianta", "tu", "voltar", "menina", "agora", "voce", "vai", "sentar",
         "dou", "tapinha", "na", "potranca", "com", "o", "bumbum", "ela", "balança", "Se", "eu", "te", "chamo", "de",
         "malandra", "Você", "vai", "se", "apaixonar", "Dou", "tapinha", "na", "potranca", "Com", "o", "bumbum", "ela", "balanca",
         "Se", "eu", "te", "chamo", "de", "malandra", "Voce", "vai", "se", "apaixonar", "Ah", "ah", "aaaaaah", "Agora",
         "vai", "sentar!", "Vai", "sentar!", "Vai", "sentar!", "Vai", "sentar!", "Vai", "sentar!"
     };*/


    

    private static int index = 0;

    public static string GetFunkWord()
    {
        //int randomIndex = Random.Range(0, wordList.Length);

        string randomWord;//The variable name is wrong, potranca. You should change that, novinha.

        if (index == wordList.Length)
        {
            index =0;
        }

        randomWord = wordList[index];
        index++;

        return randomWord;

        

    }
}
