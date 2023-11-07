using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ColoringWithKeys : MonoBehaviour
{
    public bool colorWasChosen;

    public int colorIndex = -1;
    public int colorAreaIndex = -1;

    GameObject currentColor;
    GameObject currentArea;

    Color chosenColorValue;

    [SerializeField] List<GameObject> colors = new List<GameObject>();
    [SerializeField] List<GameObject> colors_12 = new List<GameObject>();
    [SerializeField] List<GameObject> colors_36 = new List<GameObject>();
    [SerializeField] Coloring coloring;

    private void Start()
    {

        if (ChosenPicture.chosenPicture.easy)
        {
            colors.AddRange(colors_12);

        }
        else if (ChosenPicture.chosenPicture.hard)
        { 
            colors.AddRange(colors_36);
        }
    }
    void Update()
    {
        if (!colorWasChosen)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {             
                if (coloring.color != null)
                {
                    return;
                }
                coloring.highlight.SetActive(true);
                ChangeColor();
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (coloring.currentColor == null)
                {
                    colorWasChosen = false;
                }
                else
                {
                    colorWasChosen = true;
                    SpriteRenderer spriteRenderer = currentColor.GetComponent<SpriteRenderer>();
                    chosenColorValue = spriteRenderer.color;
                    coloring.currentColor = chosenColorValue;
                    coloring.chosenColorHighlight.transform.position = currentColor.transform.position;
                    coloring.highlight.SetActive(false);

                }
            }
        }
        else 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangeColoringArea();
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (currentArea != null)
                {   
                    coloring.ColorTheArea(currentArea);
                    colorWasChosen = false;            
                    colorIndex = -1;
                    colorAreaIndex = -1;                           
                }             
            }
        }
    }

    public void ChangeColor()
    {
        if (colors.Count == 0)
        {
            return;
        }

        colorIndex = (colorIndex + 1) % colors.Count;

        currentColor = colors[colorIndex];

        coloring.highlight.transform.position = currentColor.transform.position;
        
    }

    public void ChangeColoringArea()
    {
        if (coloring.coloringAreas.Count == 0)
        {
            return;
        }
        if (currentArea != null)
        {
            SpriteRenderer sprireRendererTest = currentArea.GetComponent<SpriteRenderer>();
            ResetColor(currentArea, sprireRendererTest);

        }
       
        colorAreaIndex = (colorAreaIndex + 1) % coloring.coloringAreas.Count;

        currentArea = coloring.coloringAreas[colorAreaIndex];

        SpriteRenderer sprireRenderer = currentArea.GetComponent<SpriteRenderer>();
        coloring.originalColor = sprireRenderer.color;
            if (!coloring.ObjectsAndTheirColorsDictionary.ContainsKey(currentArea))
            {
                coloring.ObjectsAndTheirColorsDictionary.Add(currentArea, coloring.originalColor);
            }

            sprireRenderer.color = coloring.currentColor;
    }

    public void ResetColor(GameObject currentArea, SpriteRenderer spriteRenderer)
    {
        if (currentArea != null)
        {
            if (coloring.ObjectsAndTheirColorsDictionary.ContainsKey(currentArea))
            {
                spriteRenderer.color = coloring.ObjectsAndTheirColorsDictionary[currentArea];
            }
        }
    }
}
