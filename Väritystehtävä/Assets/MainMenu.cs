using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
 
    bool skip;
    [SerializeField] List<Button> buttons = new List<Button>();
    [SerializeField] List<Button> uiButtons = new List<Button>();
    [SerializeField] List<Button> instructionButtons = new List<Button>();

    private void Start()
    {
        GameData.gameData.currentIndex = -1;
    }
    private void Update()
    {
        
        if (GameData.gameData.instructions)
        {
            buttons = instructionButtons;
        }
        else
        {
            buttons = uiButtons;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
            {

                int nextIndex = GameData.gameData.currentIndex;

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

                GameData.gameData.currentIndex = nextIndex;
                buttons[GameData.gameData.currentIndex].Select();
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
