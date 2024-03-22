using UnityEngine;
public class GameData : MonoBehaviour
{
    public string currentPicture;
    public bool easy;
    public bool hard;
    public bool audioMuted;

    public bool skip;
    public bool savingAnImage;
    public bool IsOnMobile;
    public bool instructions;
    public int currentIndex;

    public static GameData gameData;

    //Stores game data across scenes
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
    }
}
