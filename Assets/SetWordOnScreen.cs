using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWordOnScreen : MonoBehaviour
{
    /*public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject go = GameObject.Find("WordManager");

        List<Word> list = go.GetComponent<WordManager>().words;

        Word w = go.GetComponent<WordManager>().FindWordInList(collision.gameObject.name);

        w.SetToOnScreen();

    }*/

    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject go = GameObject.Find("WordManager");

        List<Word> list = go.GetComponent<WordManager>().words;

        Word w = go.GetComponent<WordManager>().FindWordInList(other.gameObject.name);

        w.SetToOnScreen();
    }
}
