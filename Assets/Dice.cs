
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{

    public static Text highScore;

    public void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void SetHighScore()
    {
        //one u lose, you will se your high score at the lose panel

        //we need to get that score number once the game ends or end panel appears

        int number = 50;

        if (number > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", number);
            highScore.text = number.ToString();
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore.text = "0";
    }
}
