using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;


public class CursorController : MonoBehaviour
{
    public Texture2D defaultCursor;
    public Texture2D hoverCursor;
    bool hovering;
    [SerializeField] Vector2 hotspotDefault = new Vector2(8, 5);
    [SerializeField] Vector2 hotspotHover = new Vector2(10, 6);
   


    public static CursorController cursor;

    //void Start()
    //{
    //    // Set the default cursor
    //    ChangeCursor(defaultCursor, hotspotDefault);

    //    if (cursor == null)
    //    {
    //        DontDestroyOnLoad(gameObject);
    //        cursor = this;
    //    }
    //    else
    //    {

    //        Destroy(gameObject);
    //    }
    //}

    public void ChangeCursor(Texture2D cursorType, Vector2 hotspot)
    {
        Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
    } //x8 y5  x10 y6

    void Update()
    {
        if (hovering || CheckForClickableObjects())
        {
            ChangeCursor(hoverCursor, hotspotHover);
        }
        else
        {
            ChangeCursor(defaultCursor, hotspotDefault);
     
        }

      
    }
    public void Hovering()
    {
        hovering = true;
    }
    public void ExitHovering()
    {
        hovering = false;
    }
    bool IsPointerOverSpecificUIElement()
    {
        // Create a pointer event data
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;

        // Perform raycast
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach (RaycastResult result in results)
        {

            GameObject hitObject = result.gameObject;
            if (!hitObject.CompareTag("Interactable"))
            {
                // Check if the hit object has the "Button" or "Color" tag
                if (hitObject.CompareTag("Button") || hitObject.CompareTag("Picture"))
                {
                        return true;
                    
                }
            }
         
        }

        return false;
    }

    bool CheckForClickableObjects()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit)
        {
            if (!GameData.gameData.instructions && !GameData.gameData.savingAnImage)
            {


                if (hit.collider.gameObject.CompareTag("Color") || hit.collider.gameObject.CompareTag("ColoringArea"))
                {
                    return true;
                }
            }
        }
       
        return false;
    }

}
