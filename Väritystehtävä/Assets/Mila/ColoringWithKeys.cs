using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoringWithKeys : MonoBehaviour
{
    [SerializeField] List<GameObject> colors = new List<GameObject>();
  
    [SerializeField] Coloring coloring;

    bool colorWasChosen;
    int colorIndex;
    int colorAreaIndex;
    GameObject currentColor;
    GameObject currentArea;

    Color chosenColorValue;

    // Update is called once per frame
    void Update()
    {
        if (!colorWasChosen)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
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
                }
            }
        }
        else 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangeColoringArea();
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
