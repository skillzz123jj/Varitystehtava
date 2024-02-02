using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pictures : MonoBehaviour
{
    [SerializeField] GameObject highlight;
    [SerializeField] GameObject keyHighlight;
    [SerializeField] GameObject easyKeyHighlight;
    [SerializeField] GameObject hardKeyHighlight;
    [SerializeField] GameObject easyHighlight;
    [SerializeField] GameObject hardHighlight;
    [SerializeField] GameObject easyImages;
    [SerializeField] GameObject hardImages;

    List<Button> buttons = new List<Button>();
    [SerializeField] List<Button> uiButtons = new List<Button>();

    int pictureIndex = -1;


    private int currentIndex;

    private void Start()
    {
        if (GameData.gameData.easy)
        {

            easyImages.SetActive(true);
            FindAndAddButtons(easyImages.transform);
            easyHighlight.SetActive(true);
            highlight = easyHighlight;
            keyHighlight = easyKeyHighlight;
               
        }
        else if (GameData.gameData.hard) 
        { 
            
            hardImages.SetActive(true);
            FindAndAddButtons(hardImages.transform);
            hardHighlight.SetActive(true);
            highlight = hardHighlight;
            keyHighlight = hardKeyHighlight;

        } 
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            int nextIndex = currentIndex;

           

            do
            {
                nextIndex = (nextIndex + 1) % buttons.Count;
                if (buttons[nextIndex].gameObject.CompareTag("UI"))
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


        //    if (Input.GetKeyDown(KeyCode.Space))
        //{            
        //    pictureIndex = (pictureIndex + 1) % buttons.Count;
        //    highlight.SetActive(false);
        //    keyHighlight.SetActive(true);   
        //    buttons[pictureIndex].Select();
        //    keyHighlight.transform.position = buttons[pictureIndex].transform.position;
          
        //}
    }

    public void HoverOnImage(int picture)
    {

        buttons[picture].Select();
        highlight.SetActive(true);
        keyHighlight.SetActive(false);
        highlight.transform.position = buttons[picture].transform.position;


    }
    public void OnHoverExit()
    {
        pictureIndex = -1;
    }
    public void Picture(GameObject image)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            return;
        }
        GameData.gameData.currentPicture = image.name;
    }
    public void ChangeScene(int scene)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            return;
        }
        SceneManager.LoadScene(scene);

    }
    int amountOfPictures;
    void FindAndAddButtons(Transform parentTransform)
    {
        // Iterate through all immediate children of the parentTransform
        foreach (Transform childTransform in parentTransform)
        {
            // Attempt to get a Button component from the child
            Button button = childTransform.GetComponent<Button>();

            if (button != null)
            {
                // Add the button to the List<Button>
                amountOfPictures++;
                buttons.Add(button);
            }
        }
        buttons.AddRange(uiButtons);

    }
    public void NewPicture(int scene)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            return;
        }

        SceneManager.LoadScene(scene);
    }
}

