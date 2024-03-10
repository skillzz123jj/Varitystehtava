using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorChange : MonoBehaviour
{
    public Texture2D defaultCursor;
    public Texture2D hoverCursor;

    void Start()
    {
        // Set the default cursor
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    void Update()
    {
        // Check if the mouse is hovering over any UI element with a Button component
        if (EventSystem.current.IsPointerOverGameObject())
        {
            // Change cursor to the hoverCursor texture
            Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.ForceSoftware);
        }
        else
        {
            // If not hovering over a UI button, revert to the default cursor
            Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}
