using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pictures : MonoBehaviour
{
    [SerializeField] GameObject highlight;
    [SerializeField] Button[] easyImages;
    int pictureIndex = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {            
            pictureIndex = (pictureIndex + 1) % easyImages.Length;

            easyImages[pictureIndex].Select();
            highlight.transform.position = easyImages[pictureIndex].transform.position;
          
        }
    }
    public void test(int picture)
    {
        easyImages[picture].Select();
        highlight.transform.position = easyImages[picture].transform.position;
        pictureIndex = picture;

    }
    public void Picture(GameObject image)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            return;
        }
        ChosenPicture.chosenPicture.currentPicture = image.name;
    }
    public void ChangeScene(int scene)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            return;
        }
        SceneManager.LoadScene(scene);

    }
  
}
