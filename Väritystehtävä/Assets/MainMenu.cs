using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    int currentIndex = 0;
    bool skip;
    [SerializeField] List<Button> buttons = new List<Button>();
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            int nextIndex = currentIndex;

            do
            {
                nextIndex = (nextIndex + 1) % buttons.Count;
                if (GameData.gameData.skip)
                {

                    nextIndex = (nextIndex + 1) % buttons.Count;
                    GameData.gameData.skip = false;
                }

            }
            while (!buttons[nextIndex].interactable);

            currentIndex = nextIndex;
            buttons[currentIndex].Select();
        }
    }
    public void PlayGame()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            return;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void AloitusMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void Easy()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            return;
        }

        GameData.gameData.easy = true;
        GameData.gameData.hard = false;

    }

    public void Hard()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            return;
        }
        GameData.gameData.easy = false;
        GameData.gameData.hard = true;
    }
}
