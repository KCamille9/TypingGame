using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSong : MonoBehaviour
{
    public void StartAgoraVaiSentar()
    {
        SceneManager.LoadScene("AgoraVaiSentarScn");
    }

    public void StartDeuOnda()
    {
        SceneManager.LoadScene("DeuOndaScn");

    }
}
