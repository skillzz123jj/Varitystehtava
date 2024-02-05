using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class SaveImage : MonoBehaviour
{
    [SerializeField] Button save;
    [SerializeField] Button saveImage;
    [SerializeField] List<Button> buttons = new List<Button>();
    [SerializeField] List<Button> lowerButtons = new List<Button>();
  
    [SerializeField] GameObject background;
    [SerializeField] GameObject colors;
    [SerializeField] GameObject paper;
    [SerializeField] GameObject easyPaper;
    [SerializeField] GameObject hardPaper;
    [SerializeField] GameObject easyColors;
    [SerializeField] GameObject hardColors;
    [SerializeField] GameObject highLights;
    [SerializeField] GameObject uiButtons;
    [SerializeField] GameObject uiButtonsMobile;
    [SerializeField] GameObject saveImageScreen;

    int buttonIndex;
    public int UpScale = 4;

    //bool mobile = false;
    public bool AlphaBackground = true;

    public Texture2D screenshot;
    [SerializeField] Camera screenshotCamera;

    [SerializeField] Coloring coloring;
    [SerializeField] ColoringWithKeys coloringWithKeys;
    void Start()
    {
        if (GameData.gameData.easy)
        {
            colors = easyColors;
            paper = easyPaper;

        }
        else if (GameData.gameData.hard)
        {
            colors = hardColors;
            paper = hardPaper;

        }
        if (GameData.gameData.IsOnMobile)
        {
            uiButtons = uiButtonsMobile;
        }

        //if (Application.platform == RuntimePlatform.WebGLPlayer)
        //{
        //    if (Application.isMobilePlatform)
        //    {
        //        mobile = true;
        //    }
        //    else
        //    {
        //        mobile = false;
        //    }
        //}
    }


    void Update()
    {
        if (coloringWithKeys.savingImage)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                buttonIndex = (buttonIndex + 1) % buttons.Count;

                buttons[buttonIndex].Select();

            }
        }   
    }

    public void SaveScreenshot()
    {
        TakeScreenshot();

        background.SetActive(true);
        colors.SetActive(true);
        highLights.SetActive(true);
    }
    public void SaveScreenshotButton()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            return;
        }
        save.interactable = false;
        Invoke("DelayedSaveScreenshot", 2f);
    }

    void DelayedSaveScreenshot()
    {     
        SaveScreenshot(screenshot);
        save.interactable = true; 
    }
 
    public void CloseScreenshotSaving()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            return;
       
        }
        Destroy(screenshot);
        saveImageScreen.SetActive(false);
        coloringWithKeys.enabled = true;
        coloring.enabled = true;
        coloringWithKeys.savingImage = false;
        saveImage.Select();
        ButtonStatus(true);
       

    }
    public Button defaultButton;
    public void TakeScreenshotButton()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            return;
        }
        coloring.highlight.SetActive(false);
        buttonIndex = 1;
        coloringWithKeys.savingImage = true;
        ButtonStatus(false); 
        StartCoroutine(TakeScreenshot());      

    }

    void ButtonStatus(bool interactable)
    {
        foreach (Button button in lowerButtons)
        {
            button.interactable = interactable;
        }
    }
  
    public void SaveScreenshot(Texture2D screenshotTexture)
    {
        byte[] compressedBytes = screenshotTexture.EncodeToPNG();

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
 
    Texture2D CreateScreenshot()
    {
        int w = screenshotCamera.pixelWidth * UpScale;
        int h = screenshotCamera.pixelHeight * UpScale;
        background.SetActive(false);
        colors.SetActive(false);
        highLights.SetActive(false);
        paper.SetActive(false);
        uiButtons.SetActive(false);

        RenderTexture rt = new RenderTexture(w, h, 32);
        screenshotCamera.targetTexture = rt;
        var screenShot = new Texture2D(w, h, TextureFormat.ARGB32, false);
        var clearFlags = screenshotCamera.clearFlags;
        if (AlphaBackground)
        {
            screenshotCamera.clearFlags = CameraClearFlags.SolidColor;
            screenshotCamera.backgroundColor = new Color(0, 0, 0, 0);
        }
        screenshotCamera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, w, h), 0, 0);
        screenShot.Apply();

        screenshotCamera.targetTexture = null;
        RenderTexture.active = null;
        DestroyImmediate(rt);
        screenshotCamera.clearFlags = clearFlags;
        return screenShot;
    }
 
        IEnumerator TakeScreenshot()
        {
            yield return new WaitForEndOfFrame();
            Texture2D screenshotTexture = CreateScreenshot();
            screenshot = screenshotTexture; 
        

            coloringWithKeys.enabled = false;
            coloring.enabled = false;
            background.SetActive(true);
            colors.SetActive(true);
            highLights.SetActive(true);
            paper.SetActive(true);
            uiButtons.SetActive(true);
           buttons[buttonIndex].Select();
            saveImageScreen.SetActive(true);
        buttonIndex = 0;
           EventSystem.current.SetSelectedGameObject(defaultButton.gameObject);
    }
}



//Texture2D CompressAndDownsampleTexture(Texture2D originalTexture)
//{
//    int maxSize = 2048;
//    //2048

//    // Downsample the texture if it exceeds the maximum size
//    if (originalTexture.width > maxSize || originalTexture.height > maxSize)
//    {
//        int newWidth = Mathf.Min(originalTexture.width, maxSize);
//        int newHeight = Mathf.Min(originalTexture.height, maxSize);

//        // Create a new downsampled texture without destroying the original one
//        Texture2D downsampledTexture = new Texture2D(newWidth, newHeight);
//        for (int x = 0; x < newWidth; x++)
//        {
//            for (int y = 0; y < newHeight; y++)
//            {
//                downsampledTexture.SetPixel(x, y, originalTexture.GetPixelBilinear((float)x / newWidth, (float)y / newHeight));
//            }
//        }
//        downsampledTexture.Apply();

//        // Compress the downsampled texture before converting to PNG
//        byte[] compressedBytes = downsampledTexture.EncodeToPNG();
//        Destroy(downsampledTexture);

//        // Create a new Texture2D to load the compressed bytes
//        Texture2D compressedTexture = new Texture2D(2, 2);
//        compressedTexture.LoadImage(compressedBytes);

//        return compressedTexture;
//    }

//    // If no downsampling is needed, directly compress the original texture
//    byte[] compressedOriginalBytes = originalTexture.EncodeToPNG();
//    Texture2D compressedOriginalTexture = new Texture2D(2, 2);
//    compressedOriginalTexture.LoadImage(compressedOriginalBytes);

//    return compressedOriginalTexture;
//}


//Rect CalculateNonTransparentBounds(Texture2D targetTexture)
//{
//    Color[] pixels = targetTexture.GetPixels();

//    int minX = targetTexture.width;
//    int minY = targetTexture.height;
//    int maxX = 0;
//    int maxY = 0;

//    // Iterate through each pixel to find the bounds of non-transparent pixels
//    for (int x = 0; x < targetTexture.width; x++)
//    {
//        for (int y = 0; y < targetTexture.height; y++)
//        {
//            if (pixels[y * targetTexture.width + x].a > 0)
//            {
//                // Found a non-transparent pixel
//                minX = Mathf.Min(minX, x);
//                minY = Mathf.Min(minY, y);
//                maxX = Mathf.Max(maxX, x);
//                maxY = Mathf.Max(maxY, y);
//            }
//        }
//    }

//    // Calculate the rect bounds
//    int width = maxX - minX + 1;
//    int height = maxY - minY + 1;

//    return new Rect(minX, minY, width, height);
//}

//  public Texture2D texture; 

//Texture2D croppedTexture;
//void CropTexture(Texture2D targetTexture)
//{
//    Color[] pixels = targetTexture.GetPixels();
//    Rect nonTransparentRect = CalculateNonTransparentBounds(targetTexture);

//    // Create a new texture with the non-transparent bounds
//    croppedTexture = new Texture2D((int)nonTransparentRect.width, (int)nonTransparentRect.height);
//    croppedTexture.SetPixels(targetTexture.GetPixels((int)nonTransparentRect.x, (int)nonTransparentRect.y, (int)nonTransparentRect.width, (int)nonTransparentRect.height));
//    croppedTexture.Apply();

//    // Optional: Replace the original texture with the cropped one
//    // targetTexture = croppedTexture;

//    // You can now use 'croppedTexture' for further processing or rendering
//}