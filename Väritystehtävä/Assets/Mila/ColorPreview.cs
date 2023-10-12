using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPreview : MonoBehaviour
{
    RaycastHit2D newHit;
    GameObject coloringArea;
    Color originalColor;
    public Color currentColor;
    Dictionary<GameObject, Color> ObjectsAndTheirColorsDictionary = new Dictionary<GameObject, Color>();

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        newHit = Physics2D.Raycast(mousePosition, Vector2.zero);

        //This is constantly checking whether the player is hovering over a coloring area or not
        if (newHit.collider != null)
        {
            if (newHit.collider.gameObject != coloringArea && newHit.collider.CompareTag("ColoringArea"))
            {
                OnHoverExit();
                coloringArea = newHit.collider.gameObject;
                OnHoverEnter();
              
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
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (newHit.collider != null && newHit.collider.gameObject.CompareTag("ColoringArea"))
            {
                Debug.Log("working");
                ColorTheArea(newHit.collider.gameObject);       

            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (newHit.collider != null && newHit.collider.gameObject.CompareTag("Color"))
            {
                Debug.Log(newHit.collider.gameObject.name);
                GameObject test = newHit.collider.gameObject;
                SpriteRenderer spriteRenderer = test.GetComponent<SpriteRenderer>();
                currentColor = spriteRenderer.color;

            }
        }
    }

    void ColorTheArea(GameObject area)
    {
         SpriteRenderer sprireRenderer = area.GetComponent<SpriteRenderer>();
         sprireRenderer.color = currentColor;

        if (ObjectsAndTheirColorsDictionary.ContainsKey(coloringArea))
        {
            ObjectsAndTheirColorsDictionary[coloringArea] = currentColor;
        }
        else
        {
            ObjectsAndTheirColorsDictionary.Add(area, currentColor);
        }
        
    }
    //This one changes the color
    void OnHoverEnter()
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

            sprireRenderer.color = currentColor; // Color.magenta;
           // ChooseAColor.chooseAColor.currentColor
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
}