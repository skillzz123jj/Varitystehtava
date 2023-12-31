using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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

    public bool skip;

    [SerializeField] ColoringWithKeys coloringWithKeys;

    public static MenuManager menuManager;


    //All of these handle the UI buttons on the top right corner
    private void Start()
    {
   
    }
    public void DisplayInstructions()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            return;
        }
        if (coloringWithKeys != null)
        {
            coloringWithKeys.enabled = false;
        }
        InstructionTextGoAway();
        instructions.SetActive(true);
        closeInstructions.Select();

    }
    public void CloseInstructions()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            return;
        }
        if (coloringWithKeys != null)
        {
            coloringWithKeys.enabled = true;
        }
        instructions.SetActive(false);
        instructionButton.Select();
    }
    public void reloadGame(int scene)
    {


        if (Input.GetKey(KeyCode.Space))
        {
            return;
        }

        SceneManager.LoadScene(scene);
    }
    public void QuitGame()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            return;
        }

        Application.Quit();
    }
    public void MuteAudio()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            return;
        }
        muteAudioAsDefault.interactable = true;
        audioAsDefault.interactable = false;
        GameData.gameData.audioMuted = true;

        audioButton.SetActive(false);
        muteAudioButton.SetActive(true);
        muteAudioText.SetActive(false);
        EventSystem.current.SetSelectedGameObject(muteAudioAsDefault.gameObject);


    }

    public void Audio()
    {
   
        if (Input.GetKey(KeyCode.Space))
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
