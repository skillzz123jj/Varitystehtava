using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ManagePictures : MonoBehaviour
{
    [SerializeField] GameObject easycoloring;
    [SerializeField] GameObject hardColoring;
    [SerializeField] List<GameObject> pictures = new List<GameObject>();
    [SerializeField] Coloring coloring;


    void Start()
    {
        if (ChosenPicture.chosenPicture.easy)
        {
            easycoloring.SetActive(true);
            hardColoring.SetActive(false);

        }
        else if (ChosenPicture.chosenPicture.hard)
        {
            easycoloring.SetActive(false);   
            hardColoring.SetActive(true);

        }
        string chosenImage = ChosenPicture.chosenPicture.currentPicture;
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
