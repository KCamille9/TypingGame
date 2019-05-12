using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detroyItself : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //bool test = wm.WordInList("voce");

        GameObject go = GameObject.Find("WordManager");

        List<Word> list = go.GetComponent<WordManager>().words;

        Word w = go.GetComponent<WordManager>().FindWordInList(this.gameObject.name);

        Debug.Log(w);

        list.Remove(w);

        Destroy(this.gameObject);
        //Destroy(collision.gameObject);
    }
}
