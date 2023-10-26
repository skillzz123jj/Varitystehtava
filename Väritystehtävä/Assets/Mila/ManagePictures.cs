using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePictures : MonoBehaviour
{
    [SerializeField] List<GameObject> pictures = new List<GameObject>();
    [SerializeField] Coloring coloring;


    void Start()
    {
        string chosenImage = ChosenPicture.chosenPicture.currentPicture;
        FindImage(chosenImage);
    }

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
