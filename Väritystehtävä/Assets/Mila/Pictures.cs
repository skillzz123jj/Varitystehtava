using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pictures : MonoBehaviour
{
    public GameObject currentPicture;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            EasyImages(currentPicture);
        }
    }

    public void Picture(GameObject image)
    {
        currentPicture = image;
    }
    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);

    }
    void EasyImages(GameObject currentPicture)
    {
        switch (currentPicture.name)
        {
            case "Plane":
             
                Debug.Log(currentPicture.name);
                break;

            case "Apartment":
            
                Debug.Log(currentPicture.name);
                break;

            case "Books":
               
                Debug.Log(currentPicture.name);
                break;

            case "Dog":
              
                Debug.Log(currentPicture.name);
                break;

            case "Fish":
             
                Debug.Log(currentPicture.name);
                break;
            case "Flower":
              
                Debug.Log(currentPicture.name);
                break;
            case "House":
               
                Debug.Log(currentPicture.name);
                break;

            case "Pear":
            
                Debug.Log(currentPicture.name);
                break;

            case "Presents":
               
                Debug.Log(currentPicture.name);
                break;
            case "Tree":
               
                Debug.Log(currentPicture.name);
                break;

            case "Unicorn":
             
                Debug.Log(currentPicture.name);
                break;

            case "Dragon":
           
                Debug.Log(currentPicture.name);
                break;
          
        }
    }
}
