using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosenPicture : MonoBehaviour
{
    public string currentPicture;
    public bool easy;
    public bool hard;

    public static ChosenPicture chosenPicture;

    void Start()
    {
        if (chosenPicture == null)
        {
            DontDestroyOnLoad(gameObject);
            chosenPicture = this;
        }
        else
        {

            Destroy(gameObject);
        }
    }
}
