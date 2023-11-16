
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Cache;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class SaveImage : MonoBehaviour
{

    void Start()
    {
        if (ChosenPicture.chosenPicture.easy)
        {
            colors = easyColors;
            paper = easyPaper;

        }
        else if (ChosenPicture.chosenPicture.hard)
        {
            colors = hardColors;
            paper = hardPaper;

        }

        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            if (Application.isMobilePlatform)
            {
                mobile = true;
            }
            else
            {
                mobile = false;
            }
        }
    }


    void Update()
    {

    }
    public string[] tagsToCapture;
    bool mobile;
    public void SaveScreenshotButton()
    {
           
        SaveScreenshot(test);       

    }
    public void CloseScreenshotSaving()
    {
        Destroy(test);
        saveImageScreen.SetActive(false);
        coloringWithKeys.enabled = true;
        coloring.enabled = true;

    }
    [SerializeField] Coloring coloring;
    [SerializeField] ColoringWithKeys coloringWithKeys;
    public void TakeScreenshotButton()
    {
        
        //if (Input.touchCount > 0)
        //{
        //    mobile = true;
        //}
        //else
        //{
        //    mobile = false;
        //}
   
        StartCoroutine(TakeScreenshot());
       

    }
    Texture2D test;
    [SerializeField] GameObject saveImageScreen;
    //IEnumerator TakeScreenshot()
    //{
    //    //Wait for the end of the frame to ensure everything is rendered
    //    yield return new WaitForEndOfFrame();
    //    // Capture the screenshot
    //    Texture2D screenshotTexture = CreateScreenshot();
    //    test = CompressAndDownsampleTexture(screenshotTexture);// ScreenCapture.CaptureScreenshotAsTexture();

    //    //if (mobile)
    //    //{
    //    //    //test = screenshotTexture;
    //    //    //Destroy(screenshotTexture);
    //    //}
    //    //else
    //    //{
    //    //    CropTexture(screenshotTexture);
    //    //    Destroy(screenshotTexture);
    //    //    test = croppedTexture;
    //    //}

    //    coloringWithKeys.enabled = false;
    //    coloring.enabled = false;
    //    background.SetActive(true);
    //    colors.SetActive(true);
    //    highLights.SetActive(true);
   
    //    paper.SetActive(true);
    //    uiButtons.SetActive(true);
    //    saveImageScreen.SetActive(true);

    //    // Convert the texture to a PNG byte array




    //    //byte[] pngBytes = screenshotTexture.EncodeToPNG();
    //    //Destroy(screenshotTexture);
    //    //// Convert the byte array to a base64-encoded string
    //    //string base64String = System.Convert.ToBase64String(pngBytes);
    //    //string screenshotName = System.DateTime.Now.ToString("dd.MM.yyyy klo HH.mm");
    //    //Debug.Log($"piirrustus {screenshotName}.png");
    //    //// Call a JavaScript function to trigger download
    //    //string jsCode = $"var a = document.createElement('a');" +
    //    //                    $"a.href = 'data:image/png;base64,{base64String}';" +
    //    //                    $"a.download = 'piirrustus {screenshotName}.png';" +
    //    //                    $"a.style.display = 'none';" +
    //    //                    $"document.body.appendChild(a);" +
    //    //                    $"a.click();" +
    //    //                    $"document.body.removeChild(a);";
    //    //Application.ExternalEval(jsCode);
    //}

    public void SaveScreenshot(Texture2D screenshotTexture)
    {
        //byte[] pngBytes = screenshotTexture.EncodeToPNG();
        //Destroy(screenshotTexture);
        //// Convert the byte array to a base64-encoded string
        //string base64String = System.Convert.ToBase64String(pngBytes);

        //Compress the texture before converting to PNG
        //byte[] compressedBytes = screenshotTexture.EncodeToJPG();
        byte[] compressedBytes = screenshotTexture.EncodeToPNG();// Use EncodeToJPG for JPEG compression

        // Convert the byte array to a base64-encoded string
        string base64String = System.Convert.ToBase64String(compressedBytes);

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

        //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //string filename = "SS-" + DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss") + ".png";
        //File.WriteAllBytes(Application.dataPath + filename, test.EncodeToPNG());
    }
    //IEnumerator TakeScreenshot()
    //{
    //    //Wait for the end of the frame to ensure everything is rendered
    //    yield return new WaitForEndOfFrame();


    //    //// Capture the screenshot
    //    Texture2D screenshotTexture = CreateScreenshot();  //ScreenCapture.CaptureScreenshotAsTexture();

    //    Destroy(screenshotTexture);
    //    Destroy(croppedTexture);

    //    //background.SetActive(true);
    //    //colors.SetActive(true);
    //    //highLights.SetActive(true);

    //    if (screenshotTexture != null)
    //    {
    //        CropTexture(screenshotTexture);
    //    }
    //    else
    //    {
    //        Debug.LogError("Texture not assigned. Please assign a texture in the Inspector.");
    //    }

    //    // Convert the texture to a PNG byte array
    //    byte[] pngBytes = croppedTexture.EncodeToPNG();
    //    Destroy(screenshotTexture);
    //    Destroy(croppedTexture);

    //    // Convert the byte array to a base64-encoded string
    //    string base64String = System.Convert.ToBase64String(pngBytes);

    //    //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    //    //string filename = "SS-" + DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss") + ".png";
    //    //File.WriteAllBytes(Application.dataPath + filename, CreateScreenshot().EncodeToPNG());



    //    background.SetActive(true);
    //    colors.SetActive(true);
    //    highLights.SetActive(true);
    //    string screenshotName = System.DateTime.Now.ToString("dd.MM.yyyy klo HH.mm");
    //    Debug.Log($"piirrustus {screenshotName}.png");

    //    //// Call a JavaScript function to trigger download
    //    string jsCode = $"var a = document.createElement('a');" +
    //                        $"a.href = 'data:image/png;base64,{base64String}';" +
    //                        $"a.download = 'piirrustus {screenshotName}.png';" +
    //                        $"a.style.display = 'none';" +
    //                        $"document.body.appendChild(a);" +
    //                        $"a.click();" +
    //                        $"document.body.removeChild(a);";
    //    Application.ExternalEval(jsCode);


    //    //background.SetActive(true);
    //    //colors.SetActive(true);
    //    //highLights.SetActive(true);

    //}




    [SerializeField] Camera camera;
    [SerializeField] GameObject background;
    [SerializeField] GameObject colors;
    [SerializeField] GameObject paper;
    [SerializeField] GameObject easyPaper;
    [SerializeField] GameObject hardPaper;
    [SerializeField] GameObject easyColors;
    [SerializeField] GameObject hardColors;
    [SerializeField] GameObject highLights;
    [SerializeField] GameObject uiButtons;
    public int UpScale = 4;

    public bool AlphaBackground = true;
    public void SaveScreenshot()
    {
        //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //string filename = "SS-" + DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss") + ".png";
        //File.WriteAllBytes(Application.dataPath + filename, CreateScreenshot().EncodeToPNG());

        TakeScreenshot();



        background.SetActive(true);
        colors.SetActive(true);
        highLights.SetActive(true);
    }
    Texture2D CreateScreenshot()
    {
        int w = camera.pixelWidth * UpScale;
        int h = camera.pixelHeight * UpScale;
        background.SetActive(false);
        colors.SetActive(false);
        highLights.SetActive(false);
        paper.SetActive(false);
        uiButtons.SetActive(false);

        RenderTexture rt = new RenderTexture(w, h, 32);
        camera.targetTexture = rt;
        var screenShot = new Texture2D(w, h, TextureFormat.ARGB32, false);
        var clearFlags = camera.clearFlags;
        if (AlphaBackground)
        {
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = new Color(0, 0, 0, 0);
        }
        camera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, w, h), 0, 0);
        screenShot.Apply();

        camera.targetTexture = null;
        RenderTexture.active = null;
        DestroyImmediate(rt);
        camera.clearFlags = clearFlags;
        return screenShot;
    }
 
        IEnumerator TakeScreenshot()
        {
            yield return new WaitForEndOfFrame();
            Texture2D screenshotTexture = CreateScreenshot();
            test = screenshotTexture;   //CompressAndDownsampleTexture(screenshotTexture);

            coloringWithKeys.enabled = false;
            coloring.enabled = false;
            background.SetActive(true);
            colors.SetActive(true);
            highLights.SetActive(true);
            paper.SetActive(true);
            uiButtons.SetActive(true);
            saveImageScreen.SetActive(true);
        }

    //Texture2D CompressAndDownsampleTexture(Texture2D originalTexture)
    //{
    //    int maxSize = 2048;

    //    // Downsample the texture if it exceeds the maximum size
    //    if (originalTexture.width > maxSize || originalTexture.height > maxSize)
    //    {
    //        int newWidth = Mathf.Min(originalTexture.width, maxSize);
    //        int newHeight = Mathf.Min(originalTexture.height, maxSize);

    //        Texture2D downsampledTexture = new Texture2D(newWidth, newHeight);
    //        Graphics.CopyTexture(originalTexture, downsampledTexture);
    //        Destroy(originalTexture);

    //        // Use the downsampled texture from now on
    //        originalTexture = downsampledTexture;
    //    }

    //    // Compress the texture before converting to PNG
    //    byte[] compressedBytes = originalTexture.EncodeToPNG();

    //    // Create a new Texture2D to load the compressed bytes
    //    Texture2D compressedTexture = new Texture2D(2, 2);
    //    compressedTexture.LoadImage(compressedBytes);

    //    return compressedTexture;
    //}

    Texture2D CompressAndDownsampleTexture(Texture2D originalTexture)
    {
        int maxSize = 2048;
        //2048

        // Downsample the texture if it exceeds the maximum size
        if (originalTexture.width > maxSize || originalTexture.height > maxSize)
        {
            int newWidth = Mathf.Min(originalTexture.width, maxSize);
            int newHeight = Mathf.Min(originalTexture.height, maxSize);

            // Create a new downsampled texture without destroying the original one
            Texture2D downsampledTexture = new Texture2D(newWidth, newHeight);
            for (int x = 0; x < newWidth; x++)
            {
                for (int y = 0; y < newHeight; y++)
                {
                    downsampledTexture.SetPixel(x, y, originalTexture.GetPixelBilinear((float)x / newWidth, (float)y / newHeight));
                }
            }
            downsampledTexture.Apply();

            // Compress the downsampled texture before converting to PNG
            byte[] compressedBytes = downsampledTexture.EncodeToPNG();
            Destroy(downsampledTexture);

            // Create a new Texture2D to load the compressed bytes
            Texture2D compressedTexture = new Texture2D(2, 2);
            compressedTexture.LoadImage(compressedBytes);

            return compressedTexture;
        }

        // If no downsampling is needed, directly compress the original texture
        byte[] compressedOriginalBytes = originalTexture.EncodeToPNG();
        Texture2D compressedOriginalTexture = new Texture2D(2, 2);
        compressedOriginalTexture.LoadImage(compressedOriginalBytes);

        return compressedOriginalTexture;
    }


    // ... (rest of your code)

    //Texture2D CompressAndDownsampleTexture(Texture2D originalTexture)
    //{
    //    // Choose a reasonable maximum size for your needs
    //    int maxSize = 2048;

    //    // Downsample the texture if it exceeds the maximum size
    //    if (originalTexture.width > maxSize || originalTexture.height > maxSize)
    //    {
    //        int newWidth = Mathf.Min(originalTexture.width, maxSize);
    //        int newHeight = Mathf.Min(originalTexture.height, maxSize);

    //        Texture2D downsampledTexture = new Texture2D(newWidth, newHeight);
    //        Graphics.CopyTexture(originalTexture, downsampledTexture);
    //        Destroy(originalTexture);

    //        // Use the downsampled texture from now on
    //        originalTexture = downsampledTexture;

    //    }
    //    return originalTexture;
    //    // Compress the texture before converting to PNG
    //    //byte[] compressedBytes = originalTexture.EncodeToJPG(); // Use EncodeToJPG for JPEG compression

    //    //// Convert the byte array to a base64-encoded string
    //    //string base64String = System.Convert.ToBase64String(compressedBytes);

    //    // ... (rest of your code)
    //}

    public Texture2D texture;  // Assign your texture in the Inspector

    Texture2D croppedTexture;
    void CropTexture(Texture2D targetTexture)
    {
        Color[] pixels = targetTexture.GetPixels();
        Rect nonTransparentRect = CalculateNonTransparentBounds(targetTexture);

        // Create a new texture with the non-transparent bounds
        croppedTexture = new Texture2D((int)nonTransparentRect.width, (int)nonTransparentRect.height);
        croppedTexture.SetPixels(targetTexture.GetPixels((int)nonTransparentRect.x, (int)nonTransparentRect.y, (int)nonTransparentRect.width, (int)nonTransparentRect.height));
        croppedTexture.Apply();

        // Optional: Replace the original texture with the cropped one
        // targetTexture = croppedTexture;

        // You can now use 'croppedTexture' for further processing or rendering
    }

    Rect CalculateNonTransparentBounds(Texture2D targetTexture)
    {
        Color[] pixels = targetTexture.GetPixels();

        int minX = targetTexture.width;
        int minY = targetTexture.height;
        int maxX = 0;
        int maxY = 0;

        // Iterate through each pixel to find the bounds of non-transparent pixels
        for (int x = 0; x < targetTexture.width; x++)
        {
            for (int y = 0; y < targetTexture.height; y++)
            {
                if (pixels[y * targetTexture.width + x].a > 0)
                {
                    // Found a non-transparent pixel
                    minX = Mathf.Min(minX, x);
                    minY = Mathf.Min(minY, y);
                    maxX = Mathf.Max(maxX, x);
                    maxY = Mathf.Max(maxY, y);
                }
            }
        }

        // Calculate the rect bounds
        int width = maxX - minX + 1;
        int height = maxY - minY + 1;

        return new Rect(minX, minY, width, height);
    }
}




