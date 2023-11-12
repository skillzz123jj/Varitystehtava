using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Cache;
using System.Text.RegularExpressions;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class SaveImage : MonoBehaviour
{
    
    void Start()
    {
      
    }


    void Update()
    {
        
    }
    public string[] tagsToCapture;
    public void TakeScreenshotButton()
    {
        StartCoroutine(TakeScreenshot());
    }

    IEnumerator TakeScreenshot()
    {
        //Wait for the end of the frame to ensure everything is rendered
           yield return new WaitForEndOfFrame();

        // Capture the screenshot
        Texture2D screenshotTexture = ScreenCapture.CaptureScreenshotAsTexture();

        // Convert the texture to a PNG byte array
        byte[] pngBytes = screenshotTexture.EncodeToPNG();
        Destroy(screenshotTexture);

        // Convert the byte array to a base64-encoded string
        string base64String = System.Convert.ToBase64String(pngBytes);


        string screenshotName = System.DateTime.Now.ToString("dd.MM.yyyy klo HH.mm");
        Debug.Log($"piirrustus {screenshotName}.png");

        // Call a JavaScript function to trigger download
        string jsCode = $"var a = document.createElement('a');" +
                            $"a.href = 'data:image/png;base64,{base64String}';" +
                            $"a.download = 'piirrustus {screenshotName}.png';" +
                            $"a.style.display = 'none';" +
                            $"document.body.appendChild(a);" +
                            $"a.click();" +
                            $"document.body.removeChild(a);";
        Application.ExternalEval(jsCode);

    }
}








