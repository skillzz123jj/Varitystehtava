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
        ChosenPicture.chosenPicture.easy = true;
        ChosenPicture.chosenPicture.hard = false;
    }

    public void Hard()
    {
        ChosenPicture.chosenPicture.easy = false;
        ChosenPicture.chosenPicture.hard = true;

    }
}
