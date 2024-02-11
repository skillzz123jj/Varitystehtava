using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ColoringWithKeys : MonoBehaviour
{
    public bool colorWasChosen;
    public bool savingImage;

    public int colorIndex = 0;
    public int colorAreaIndex = -1;

    GameObject currentColor;
    GameObject currentArea;

    Color chosenColorValue;

    [SerializeField] public GameObject highlightKeys;
    [SerializeField] GameObject highlightKeysEasy;
    [SerializeField] GameObject highlightKeysHard;

    [SerializeField] List<GameObject> colors = new List<GameObject>();
    [SerializeField] List<GameObject> colors_12 = new List<GameObject>();
    [SerializeField] List<GameObject> colors_36 = new List<GameObject>();
    [SerializeField] List<GameObject> uiButtons = new List<GameObject>();
    [SerializeField] Coloring coloring;

    [SerializeField] AudioSource drawingSound;

    private void Start()
    {

        if (GameData.gameData.easy)
        {
            colors.AddRange(colors_12);
            highlightKeys = highlightKeysEasy;
        }
        else if (GameData.gameData.hard)
        {

            colors.AddRange(colors_36);
            highlightKeys = highlightKeysHard;
        }
        colors.AddRange(uiButtons);
    }
    void Update()
    {
        if (!savingImage)
        {
            if (!colorWasChosen)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    highlightKeys.SetActive(true);
                    ChangeColor();
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (coloring.currentColor == null)
                    {
                        colorWasChosen = false;
                    }
                    else if (currentColor.CompareTag("Color"))
                    {
                        colorWasChosen = true;
                        SpriteRenderer spriteRenderer = currentColor.GetComponent<SpriteRenderer>();
                        chosenColorValue = spriteRenderer.color;
                        coloring.currentColor = chosenColorValue;
                        coloring.chosenColorHighlight.transform.position = currentColor.transform.position;
                        coloring.chosenColorHighlight.SetActive(true);
                        highlightKeys.SetActive(false);

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
                        drawingSound.Play();
                        coloring.ColorTheArea(currentArea);
                        colorWasChosen = false;
                        colorIndex = 0;
                        colorAreaIndex = -1;
                        coloring.currentColor = Color.white;
                        coloring.chosenColorHighlight.SetActive(false);
                    }
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

        if (currentColor != null)
        {
            if (currentColor.CompareTag("UI"))
            {
                Button inactiveButton = currentColor.GetComponent<Button>();

                if (!inactiveButton.interactable && inactiveButton != null)
                {
                    ChangeColor();
                }

                highlightKeys.SetActive(false);
                coloring.highlight.SetActive(false);
                coloring.highlight.transform.position = new Vector2(-100, 0);
                Button button = currentColor.GetComponent<Button>();
                button.Select();


            }
            if (currentColor.CompareTag("Empty"))
            {
                Button button = currentColor.GetComponent<Button>();
                button.Select();
                colorIndex++;
                ChangeColor();
            }
            else
            {

                highlightKeys.transform.position = currentColor.transform.position;

            }
        }
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
