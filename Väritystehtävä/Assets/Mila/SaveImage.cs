using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    [SerializeField] GameObject blur;

    int buttonIndex;
    public int UpScale = 4;

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
    }


    void Update()
    {
        if (coloringWithKeys.savingImage)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
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
        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
        {
            return;
        }
        save.interactable = false;
        Invoke("DelayedSaveScreenshot", 2.5f);
    }

    void DelayedSaveScreenshot()
    {
        SaveScreenshot(screenshot);
        save.interactable = true;
    }

    public void CloseScreenshotSaving()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
        {
            return;

        }
        if (Input.GetKey(KeyCode.Return))
        {
            saveImage.Select();
        }
        Destroy(screenshot);
        saveImageScreen.SetActive(false);
        coloringWithKeys.enabled = true;
        coloring.enabled = true;
        coloringWithKeys.savingImage = false;
        GameData.gameData.savingAnImage = false;
        blur.GetComponent<Image>().enabled = false;
       
        ButtonStatus(true);


    }
 
    public void TakeScreenshotButton()
    {

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
        {
            return;
        }
 
        coloring.highlight.SetActive(false);
       
        blur.GetComponent<Image>().enabled = true;
        coloringWithKeys.savingImage = true;
        GameData.gameData.savingAnImage = true;
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

        //// Convert the byte array to a base64-encoded string
        string base64String = System.Convert.ToBase64String(compressedBytes);

        string screenshotName = System.DateTime.Now.ToString("dd.MM.yyyy klo HH.mm");
        // Call a JavaScript function to trigger download
        string jsCode = $"var a = document.createElement('a');" +
                            $"a.href = 'data:image/png;base64,{base64String}';" +
                            $"a.download = 'teckning {screenshotName}.png';" +
                            $"a.style.display = 'none';" +
                            $"document.body.appendChild(a);" +
                            $"a.click();" +
                            $"document.body.removeChild(a);";
        Application.ExternalEval(jsCode);

    }

    //Sets everything in the scene inactive for a transparent background and takes a screenshot
    Texture2D CreateScreenshot()
    {
        int w = Screen.width / 2;
        int h = Screen.height / 2;

        background.SetActive(false);
        colors.SetActive(false);
        highLights.SetActive(false);
        paper.SetActive(false);
        uiButtons.SetActive(false);
        blur.GetComponent<Image>().enabled = false;

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
       
        saveImageScreen.SetActive(true);
        blur.GetComponent<Image>().enabled = true;
        buttonIndex = 0;
        if (Input.GetKey(KeyCode.Return))
        {
            buttons[buttonIndex].Select();
        }
    }
}
