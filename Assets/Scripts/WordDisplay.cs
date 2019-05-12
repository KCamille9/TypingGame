using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour
{
    public Text text;
    public float fallSpeed = 1; //u can also make this random

    public void SetWord (string word)
    {
        text.text = word;
        text.color = Color.magenta;
        //text.verticalOverflow = true;
        text.fontSize = 30;
    }

    public void RemoveLetter()
    {
        text.text = text.text.Remove(0, 1); //ONLY REMOVE FIRST LETTER
        text.color = Color.cyan;
    }

    public void RemoveWord()
    {
        Destroy(gameObject);
       // Debug.Log(fallSpeed);
    }

    public void SetFallSpeed(float newFallSpeed)
    {
        fallSpeed = newFallSpeed;
    }

    private void Update()
    {
        transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f); // move word along y axis

        Vector3 bottomLeftScreenPoint = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));
        Vector3 topRightScreenPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));


        // Create bottom collider

        Vector3 size = new Vector3((bottomLeftScreenPoint.x - topRightScreenPoint.x) / 2f, topRightScreenPoint.y, 0f);

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.y < 1.0 && pos.y > 0.0)
        {

            GameObject go = GameObject.Find("WordManager");

            List<Word> list = go.GetComponent<WordManager>().words;

            Word w = go.GetComponent<WordManager>().FindWordInList(this.gameObject.name);

            w.SetToOnScreen();

            //Debug.Log(w);

        }

        //Debug.Log(transform);
    }
}
