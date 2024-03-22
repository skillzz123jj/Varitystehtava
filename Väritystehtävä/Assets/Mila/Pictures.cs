using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pictures : MonoBehaviour
{
    [SerializeField] GameObject highlight;
    [SerializeField] GameObject easyHighlight;
    [SerializeField] GameObject hardHighlight;
    [SerializeField] GameObject easyImages;
    [SerializeField] GameObject hardImages;

    List<Button> buttons = new List<Button>();
    [SerializeField] List<Button> uiButtons = new List<Button>();
    [SerializeField] List<Button> instructionButtons = new List<Button>();

    private int currentIndex;

    private void Start()
    {
        currentIndex = -1;
        GameData.gameData.currentIndex = 0;
 
        if (GameData.gameData.easy)
        {
            easyImages.SetActive(true);
            FindAndAddButtons(easyImages.transform);
            highlight = easyHighlight;
      
        }
        else if (GameData.gameData.hard)
        {
            hardImages.SetActive(true);
            FindAndAddButtons(hardImages.transform);
            highlight = hardHighlight;
          
        }  
    }

    private void Update()
    {
        if (!GameData.gameData.instructions)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
            {

                int nextIndex = currentIndex;

                do
                {
                    nextIndex = (nextIndex + 1) % buttons.Count;
                    if (buttons[nextIndex].gameObject.CompareTag("Button"))
                    {
                        highlight.SetActive(false);
                    }
                    else
                    {
                        highlight.SetActive(true);
                    }
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
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
            {

                int nextIndex = GameData.gameData.currentIndex;
               
                do
                {
                    nextIndex = (nextIndex + 1) % instructionButtons.Count;
                    if (GameData.gameData.skip)
                    {

                    nextIndex = (nextIndex + 1) % instructionButtons.Count;
                    GameData.gameData.skip = false;
                    }

                }
                while (!instructionButtons[nextIndex].interactable) ;

                GameData.gameData.currentIndex = nextIndex;
                instructionButtons[GameData.gameData.currentIndex].Select();
            }
        }
    }

    public void HoverOnImage(int picture)
    {
      
        buttons[picture].Select();
        highlight.SetActive(true);
        highlight.transform.position = buttons[picture].transform.position;

    }
    public void OnHoverExit()
    {
        currentIndex = -1;
        highlight.SetActive(false); 
    }
    public void Picture(GameObject image)
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
        {
            return;
        }
        GameData.gameData.currentPicture = image.name;
    }
    public void ChangeScene(int scene)
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
        {
            return;
        }
        SceneManager.LoadScene(scene);

    }
 
    void FindAndAddButtons(Transform parentTransform)
    {
        //Iterate through all immediate children of the parentTransform
        foreach (Transform childTransform in parentTransform)
        {
            //Attempt to get a Button component from the child
            Button button = childTransform.GetComponent<Button>();

            if (button != null)
            {
                //Add the button to the List<Button>
                buttons.Add(button);
            }
        }
        buttons.AddRange(uiButtons);

    }
    public void NewPicture(int scene)
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
        {
            return;
        }

        SceneManager.LoadScene(scene);
    }
}

