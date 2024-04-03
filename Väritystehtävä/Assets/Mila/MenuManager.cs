using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Button muteAudioAsDefault;
    [SerializeField] Button audioAsDefault;
    [SerializeField] Button closeInstructions;
    [SerializeField] Button instructionButton;
    [SerializeField] GameObject audioButton;
    [SerializeField] GameObject muteAudioButton;
    [SerializeField] GameObject exitGameText;
    [SerializeField] GameObject muteAudioText;
    [SerializeField] GameObject audioText;
    [SerializeField] GameObject restartText;
    [SerializeField] GameObject instructionText;
    [SerializeField] GameObject instructions;
    [SerializeField] GameObject blur;
    int previousIndex;

    public bool skip;

    [SerializeField] ColoringWithKeys coloringWithKeys;
    [SerializeField] Coloring coloring;

    public static MenuManager menuManager;

    //All of these handle the UI buttons on the top right corner
    public void DisplayInstructions()
    {

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
        {
            return;
        }
        if (coloring != null)
        {
         
            coloring.enabled = false;
        }
        previousIndex = GameData.gameData.currentIndex;
        GameData.gameData.instructions = true;
        InstructionTextGoAway();
        instructions.SetActive(true);
        if (Input.GetKey(KeyCode.Return))
        {

            closeInstructions.Select();
        }
        GameData.gameData.currentIndex = 0;
        blur.GetComponent<Image>().enabled = true;
        

    }
    public void CloseInstructions()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
        {
            return;
        }

        if (coloring != null)
        {
         
            coloring.enabled = true;
        }
        GameData.gameData.instructions = false;
        if (Input.GetKey(KeyCode.Return))
        {
            instructionButton.Select();

        }
        GameData.gameData.currentIndex = previousIndex;
        blur.GetComponent<Image>().enabled = false;
        instructions.SetActive(false);

    }

    public void reloadGame(int scene)
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
        {
            return;
        }

        SceneManager.LoadScene(scene);
    }
    public void QuitGame()
    {

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
        {
            return;
        }

        Application.Quit(); 
    //#if (UNITY_WEBGL)
    //    Application.OpenURL("about:blank");
    //#endif
    }
    public void MuteAudio()
    {

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
        {
            return;
        }
        muteAudioAsDefault.interactable = true;
        audioAsDefault.interactable = false;
        GameData.gameData.audioMuted = true;
        GameData.gameData.skip = true;
        audioButton.SetActive(false);
        muteAudioButton.SetActive(true);
        muteAudioText.SetActive(false);
        EventSystem.current.SetSelectedGameObject(muteAudioAsDefault.gameObject);

    }

    public void Audio()
    {

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
        {
            return;
        }
        audioAsDefault.interactable = true;
        muteAudioAsDefault.interactable = false;
        GameData.gameData.audioMuted = false;
        skip = true;
        audioButton.SetActive(true);
        muteAudioButton.SetActive(false);
        audioText.SetActive(false);
        EventSystem.current.SetSelectedGameObject(audioAsDefault.gameObject);

    }

    private void Update()
    {
        if (GameData.gameData.audioMuted)
        {
            AudioListener.volume = 0f;
            audioButton.SetActive(false);
            muteAudioButton.SetActive(true);
            muteAudioText.SetActive(false);
            muteAudioAsDefault.interactable = true;
            audioAsDefault.interactable = false;

        }
        else
        {
            AudioListener.volume = 1f;
            audioButton.SetActive(true);
            muteAudioButton.SetActive(false);
            audioText.SetActive(false);
            muteAudioAsDefault.interactable = false;
            audioAsDefault.interactable = true;

        } 
    }
    public void ExitGameText()
    {
        exitGameText.SetActive(true);
    }
    public void ExitGameTextGoAway()
    {
        exitGameText.SetActive(false);
    }
    public void RestartGameText()
    {
        restartText.SetActive(true);
    }
    public void RestartGameTextGoAway()
    {
        restartText.SetActive(false);
    }
    public void InstructionText()
    {
        instructionText.SetActive(true);
    }
    public void InstructionTextGoAway()
    {
        instructionText.SetActive(false);
    }
    public void AudioText()
    {
        audioText.SetActive(true);
    }
    public void AudioTextGoAway()
    {
        audioText.SetActive(false);
    }
    public void MuteAudioText()
    {
        muteAudioText.SetActive(true);
    }
    public void MuteAudioTextGoAway()
    {
        muteAudioText.SetActive(false);
    }
}
