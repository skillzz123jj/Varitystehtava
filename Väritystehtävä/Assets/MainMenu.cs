using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void AloitusMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void Easy()
    {
        GameData.gameData.easy = true;
        GameData.gameData.hard = false;
    }

    public void Hard()
    {
        GameData.gameData.easy = false;
        GameData.gameData.hard = true;

    }
}
