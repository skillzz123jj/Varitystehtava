using System.Collections.Generic;
using UnityEngine;

public class ManagePictures : MonoBehaviour
{
    [SerializeField] GameObject easycoloring;
    [SerializeField] GameObject hardColoring;
    [SerializeField] List<GameObject> pictures = new List<GameObject>();
    [SerializeField] Coloring coloring;
    GameObject imageObject;
    Vector2 mobilePosition = new Vector2 (-31, -14);
    Vector2 mobileScale = new Vector2(26.16f, 26.16f);
    [SerializeField] GameObject easyPaper;
   [SerializeField] GameObject hardPaper;
    [SerializeField] GameObject colors12;
    [SerializeField] GameObject colors27;
    [SerializeField] GameObject uiButtonsMobile;
    [SerializeField] GameObject uiButtons;
    [SerializeField] GameObject easyWhiteBox;
    [SerializeField] GameObject hardWhiteBox;


    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.T))    //(GameData.gameData.IsOnMobile)
    //    {
    //        imageObject.transform.localPosition = new Vector2(-127.94f, -48);
    //        imageObject.transform.localScale = new Vector2(27f, 27f);
    //        hardPaper.transform.localPosition = new Vector2(-5.56f, -8.82f);
    //        hardPaper.transform.localScale = new Vector2(1.468408f, 1.300495f);
    //        colors27.transform.localPosition = new Vector2(-18.25f, -3.99f);
    //        colors27.transform.localScale = new Vector2(1.2f, 1.2f);
    //        hardWhiteBox.transform.localScale = new Vector2(17.70506f, 10.00337f);
    //        hardWhiteBox.transform.localPosition = new Vector2(-6.3235f, -8.7915f);
    //        uiButtonsMobile.SetActive(true);
    //        uiButtons.SetActive(false);


    //    }
    //}

    void Start()
    {
        string chosenImage = GameData.gameData.currentPicture;
        FindImage(chosenImage);
        if (GameData.gameData.easy)
        {
            easycoloring.SetActive(true);
            hardColoring.SetActive(false);
            if  (GameData.gameData.IsOnMobile)
            {
                imageObject.transform.localPosition = mobilePosition;
                imageObject.transform.localScale = mobileScale;
                easyPaper.transform.localPosition = new Vector2(-6.4705f, -8.7819f);
                easyPaper.transform.localScale = new Vector2(1.437394f, 1.287404f);
                colors12.transform.localPosition = new Vector2(-17.99f, -2.84f);
                colors12.transform.localScale = new Vector2(1.5f, 1.5f);
                easyWhiteBox.transform.localScale = new Vector2(16.68705f, 9.470975f);
                easyWhiteBox.transform.localPosition = new Vector2(-6.884f, -8.7853f);
                uiButtonsMobile.SetActive(true);
                uiButtons.SetActive(false);

            }

        }
        else if (GameData.gameData.hard)
        {
            easycoloring.SetActive(false);   
            hardColoring.SetActive(true);
            if (GameData.gameData.IsOnMobile)
            {

                imageObject.transform.localPosition = new Vector2(-127.94f, -48);
                imageObject.transform.localScale = new Vector2(27f, 27f);
                hardPaper.transform.localPosition = new Vector2(-5.56f, -8.82f);
                hardPaper.transform.localScale = new Vector2(1.468408f, 1.300495f);
                colors27.transform.localPosition = new Vector2(-18.25f, -3.99f);
                colors27.transform.localScale = new Vector2(1.2f, 1.2f);
                hardWhiteBox.transform.localScale = new Vector2(17.27863f, 9.754498f);
                hardWhiteBox.transform.localPosition = new Vector2(-6.2985f, -8.7871f);
                uiButtonsMobile.SetActive(true);
                uiButtons.SetActive(false);
            }

        }
       

    }

    //Finds the chosen image's coloring areas so they can be colored with keys
    void FindImage(string image)
    {
        imageObject = pictures.Find(obj => obj.name == image);
        imageObject.SetActive(true);
        foreach (Transform area in imageObject.transform)
        {
            if (area.CompareTag("ColoringArea"))
            {
                coloring.coloringAreas.Add(area.gameObject);
            }
           
        }
       
    }
}
