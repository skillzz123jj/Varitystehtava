using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSettings : MonoBehaviour
{
    
    [SerializeField] TMP_Text text;
    bool isFinnish = true;
    [SerializeField] List<GameObject> finnishObjects = new List<GameObject>();
    [SerializeField] List<GameObject> swedishObjects = new List<GameObject>();
   

    // Start is called before the first frame update
    void Start()
    {
    

    }

    // Update is called once per frame
    void Update()
    {
          if (text)
        {
            if (GameData.gameData.finnish)
            {
                text.text = "Ruotsi";

            }
            else
            {
                text.text = "Finska";

            }

        }
        if (GameData.gameData.finnish)
        {
            foreach (GameObject obj in finnishObjects)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in swedishObjects)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject obj in finnishObjects)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in swedishObjects)
            {
                obj.SetActive(true);
            }
        }
        
    }

    public void ChangeLanguage()
    {
        isFinnish = !isFinnish;
        GameData.gameData.finnish = isFinnish;
        text.text = isFinnish ? "Ruotsi" : "Finska";
    }
}
