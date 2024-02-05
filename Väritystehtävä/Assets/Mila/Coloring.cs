using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Coloring : MonoBehaviour
{
    RaycastHit2D Hit;

    public GameObject coloringArea;
    public GameObject color;
    public GameObject highlight;
    public GameObject chosenColorHighlight;

    [SerializeField] GameObject smallerHighLight;
    [SerializeField] GameObject smallerChosenColor;

    public Color originalColor;
    public Color currentColor;

    public List<GameObject> coloringAreas = new List<GameObject>();
    public Dictionary<GameObject, Color> ObjectsAndTheirColorsDictionary = new Dictionary<GameObject, Color>();

    [SerializeField] ColoringWithKeys coloringWithKeys;
    [SerializeField] SaveImage saveImage;

    public static Coloring coloring;


    private void Start()
    {    
        if (GameData.gameData.hard)
        {
            highlight = smallerHighLight;
            chosenColorHighlight = smallerChosenColor;

            if (GameData.gameData.IsOnMobile)
            {
                highlight.transform.localScale = new Vector2(1.3f, 1.3f);
                chosenColorHighlight.transform.localScale = new Vector2(1.3f, 1.3f);
            }
        }
        else if (GameData.gameData.easy && GameData.gameData.IsOnMobile)
        {
            if (GameData.gameData.IsOnMobile)
            {
                highlight.transform.localScale = new Vector2(1.8f, 1.8f);
                chosenColorHighlight.transform.localScale = new Vector2(1.8f, 1.8f);
            }

        }
    }
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        //This is constantly checking whether the player is hovering over a coloring area or not
        if (Hit.collider != null)
        {
            if (Hit.collider.gameObject != coloringArea && Hit.collider.CompareTag("ColoringArea"))
            {
                OnHoverExit();
                coloringArea = Hit.collider.gameObject;
                OnHoverEnter();

            }
            if (Hit.collider.CompareTag("Color"))   
            {
              
                highlight.transform.position = Hit.collider.gameObject.transform.position;
                color = Hit.collider.gameObject;
                highlight.SetActive(true);
            }
            else if (coloringWithKeys.highlightKeys.transform.position == highlight.transform.position)
            {
             
                highlight.SetActive(false);
            }
  
        }
        else
        {
            //If the player isnt hovering over any areas the most recent one gets reset
            if (coloringArea != null)
            {
                OnHoverExit();
                coloringArea = null;
            }
           
            if (color != null)
            {        
                highlight.SetActive(false);
                color = null;
            }

        }
        if (Input.GetMouseButtonDown(0))
        {
            if (Hit.collider != null && Hit.collider.gameObject.CompareTag("ColoringArea"))
            {
                ColorTheArea(Hit.collider.gameObject);

            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Hit.collider != null && Hit.collider.gameObject.CompareTag("Color"))
            {
                coloringWithKeys.highlightKeys.SetActive(false);
                GameObject color = Hit.collider.gameObject;
                SpriteRenderer spriteRenderer = color.GetComponent<SpriteRenderer>();
                currentColor = spriteRenderer.color;
                coloringWithKeys.colorAreaIndex = -1;
                chosenColorHighlight.transform.position = Hit.collider.gameObject.transform.position;
                chosenColorHighlight.SetActive(true);
                highlight.SetActive(false);

            }
        }

        if (coloringWithKeys.highlightKeys.transform.position == highlight.transform.position)
        {
            
            highlight.SetActive(false);
        }
    }

    public void ColorTheArea(GameObject area)
    {
        SpriteRenderer sprireRenderer = area.GetComponent<SpriteRenderer>();
        sprireRenderer.color = currentColor;

        if (ObjectsAndTheirColorsDictionary.ContainsKey(area))
        {
            ObjectsAndTheirColorsDictionary[area] = currentColor;
        }
        else
        {
            ObjectsAndTheirColorsDictionary.Add(area, currentColor);
        }
        sprireRenderer.color = currentColor;
        coloringWithKeys.colorWasChosen = false;
        coloringWithKeys.colorIndex = -1;

    }
    //This one changes the color
    public void OnHoverEnter()
    {
        if (coloringArea != null)
        {
            SpriteRenderer sprireRenderer = coloringArea.GetComponent<SpriteRenderer>();
            originalColor = sprireRenderer.color;
            //It adds the obejct's old color in a dictionary where it can be fetched later
            if (!ObjectsAndTheirColorsDictionary.ContainsKey(coloringArea))
            {
                ObjectsAndTheirColorsDictionary.Add(coloringArea, originalColor);
            }

            sprireRenderer.color = currentColor;

        }

    }
    //And this one resets it
    void OnHoverExit()
    {
        if (coloringArea != null)
        {
            GameObject oldArea = coloringArea.gameObject;
            SpriteRenderer spriteRenderer = oldArea.GetComponent<SpriteRenderer>();

            //It fetches the previous color that was saved in the dictionary
            if (ObjectsAndTheirColorsDictionary.ContainsKey(oldArea))
            {
                spriteRenderer.color = ObjectsAndTheirColorsDictionary[oldArea];
            }
            else
            {
                spriteRenderer.color = Color.white;
            }
         

        }
    }
    public void NewPicture(int scene)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            return;
        }

        if (saveImage.screenshot != null)
        {
            Destroy(saveImage.screenshot);    
        }
        coloringWithKeys.savingImage = false;
        SceneManager.LoadScene(scene);
    }
}