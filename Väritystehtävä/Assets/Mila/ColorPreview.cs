using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPreview : MonoBehaviour
{
    RaycastHit2D newHit;
    GameObject coloringArea;
    Color originalColor;
    Dictionary<GameObject, Color> ObjectsAndTheirColorsDictionary = new Dictionary<GameObject, Color>();

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        newHit = Physics2D.Raycast(mousePosition, Vector2.zero);

        //This is constantly checking whether the player is hovering over a coloring area or not
        if (newHit.collider != null)
        {
            if (newHit.collider.gameObject != coloringArea)
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

            sprireRenderer.color = Color.magenta;
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