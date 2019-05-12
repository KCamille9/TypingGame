using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpanner : MonoBehaviour
{
    public GameObject wordPrefab;
    public Transform wordCanvas;
    public GameObject wordObj;

    public WordDisplay SpawnWord()
    {

        Vector3 randomPosition = new Vector3(Random.Range(-2.5f, 2.5f), 7f);

        wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas); //quaternion means no rotation

        //if wordObj . transform <= 0.0
        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();

        return wordDisplay;
    }

    public void SetObjectName(Word wordString)
    {
        string funkWordStr = wordString.GetWordString();

        wordObj.name = funkWordStr;
    }




}
