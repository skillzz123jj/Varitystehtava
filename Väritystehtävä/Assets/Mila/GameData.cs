using UnityEngine;

public class GameData : MonoBehaviour
{
    public string currentPicture;
    public bool easy;
    public bool hard;
    public bool audioMuted;

    public bool skip;
    public bool IsOnMobile;
    public bool instructions;
    public int currentIndex;

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

        if (Application.platform == RuntimePlatform.WebGLPlayer && Application.isMobilePlatform)
        {
            IsOnMobile = true;
        }
        else
        {
            IsOnMobile = false;
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
