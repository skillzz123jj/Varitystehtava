using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePictures : MonoBehaviour
{
    [SerializeField] List<GameObject> pictures = new List<GameObject>();
    [SerializeField] Vector2 imagePosition;
  
    void Start()
    {
        string chosenImage = ChosenPicture.chosenPicture.currentPicture;
        FindImage(chosenImage);
    }

    void FindImage(string image)
    {
        GameObject chosenImage = pictures.Find(obj => obj.name == image);
       // chosenImage.transform.position = new Vector2(imagePosition.x, imagePosition.y);
        chosenImage.SetActive(true);
    }
 
    
}
