using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pictures : MonoBehaviour
{
    public void Picture(GameObject image)
    {
        ChosenPicture.chosenPicture.currentPicture = image.name;
    }
    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);

    }
  
}
