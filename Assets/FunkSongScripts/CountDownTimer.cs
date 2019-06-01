using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    float currentTimer = 0f;
    float startingTime = 5f;

    [SerializeField]public Text countDownText;

    private void Start()
    {
        currentTimer = startingTime;
    }

    private void Update()
    {
        currentTimer -= 1 * Time.deltaTime;
        countDownText.text = currentTimer.ToString("0"); //only round numbers

        if(currentTimer <= 0)
        {
            currentTimer = 0;
        }
    }
}
