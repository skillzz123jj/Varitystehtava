using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public string currentPicture;
    public bool easy;
    public bool hard;
    public bool audioMuted;

    public bool skip;

    public static GameData gameData;

    void Start()
    {
        if (gameData == null)
        {
            DontDestroyOnLoad(gameObject);
            gameData = this;
        }
        else
        {

            Destroy(gameObject);
        }

        //if (audioMuted)
        //{
        //    MenuManager.menuManager.MuteAudio();
        //}
        //else
        //{
        //    MenuManager.menuManager.Audio();
        //}
    }
}
