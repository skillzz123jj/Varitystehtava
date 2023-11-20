using System.Collections.Generic;
using UnityEngine;

public class ManagePictures : MonoBehaviour
{
    [SerializeField] GameObject easycoloring;
    [SerializeField] GameObject hardColoring;
    [SerializeField] List<GameObject> pictures = new List<GameObject>();
    [SerializeField] Coloring coloring;


    void Start()
    {
        if (GameData.gameData.easy)
        {
            easycoloring.SetActive(true);
            hardColoring.SetActive(false);

        }
        else if (GameData.gameData.hard)
        {
            easycoloring.SetActive(false);   
            hardColoring.SetActive(true);

        }
        string chosenImage = GameData.gameData.currentPicture;
        FindImage(chosenImage);   

    }

    //Finds the chosen image's coloring areas so they can be colored with keys
    void FindImage(string image)
    {
        GameObject chosenImage = pictures.Find(obj => obj.name == image);
        chosenImage.SetActive(true);
        foreach (Transform area in chosenImage.transform)
        {
            if (area.CompareTag("ColoringArea"))
            {
                coloring.coloringAreas.Add(area.gameObject);
            }
           
        }
    }
}
