using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Credits : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] GameObject credits;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (credits.activeSelf)
        {
            text.text = "<b>Tekij�t</b>";
        }
      
    }
    public void CloseCredits()
    {
        text.text = "Tekij�t";
    }
    public void HoverCredits()
    {
        
        text.text = "<b>Tekij�t</b>";
    }

    public void ExitCredits()
    {
        text.text = "Tekij�t";
    }
}
