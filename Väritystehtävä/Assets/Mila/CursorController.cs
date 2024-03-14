using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.Playables;

public class CursorController : MonoBehaviour
{
    public Texture2D defaultCursor;
    public Texture2D hoverCursor;
    [SerializeField] Vector2 hotspot = new Vector2(0, 31);

    public static CursorController cursor;

    void Start()
    {
        // Set the default cursor
        ChangeCursor(defaultCursor);

        if (cursor == null)
        {
            DontDestroyOnLoad(gameObject);
            cursor = this;
        }
        else
        {

            Destroy(gameObject);
        }
    }

    public void ChangeCursor(Texture2D cursorType)
    {
        Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
    }

    void Update()
    {
        if (IsPointerOverSpecificUIElement() || CheckForClickableObjects())
        {
            ChangeCursor(hoverCursor);
        }
        else
        {
            ChangeCursor(defaultCursor);
     
        }
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

            // Check if the hit object has the "Button" or "Color" tag
            if (hitObject.CompareTag("Button") || hitObject.CompareTag("Picture"))
            {
                return true;
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
           
            if (hit.collider.gameObject.CompareTag("Color") || hit.collider.gameObject.CompareTag("ColoringArea"))
            {
                return true;
            }
        }
       
        return false;
    }

}
