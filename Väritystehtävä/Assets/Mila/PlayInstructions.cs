using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayInstructions : MonoBehaviour
{
    [SerializeField] AudioSource finnishAudio;
    [SerializeField] AudioSource swedishAudio;
    [SerializeField] TMP_Text buttonText;
    [SerializeField] GameObject startAudioButton;
    [SerializeField] GameObject stopAudioButton;

    public void Play()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
        {
            return;
        }
           
         StartCoroutine(PlayAudio());
                   
    }
    public void ActivateButtons()
    {

        startAudioButton.SetActive(true);
        stopAudioButton.SetActive(false);
        Button audioOff = stopAudioButton.GetComponent<Button>();
        audioOff.interactable = false;
        Button button = startAudioButton.GetComponent<Button>();
        button.interactable = true;
    }
    public void StopAudio()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab))
        {
            return;
        }

        startAudioButton.SetActive(true);
        stopAudioButton.SetActive(false);
        Button audioOff = stopAudioButton.GetComponent<Button>();
        audioOff.interactable = false;
        Button button = startAudioButton.GetComponent<Button>();
        if (GameData.gameData.instructions)
        {
            button.Select();
        }
        button.interactable = true;

        if (GameData.gameData.finnish)
        {
            finnishAudio.Stop();
        }
        else
        {
            swedishAudio.Stop();
        }
    }
    public IEnumerator PlayAudio()
    {
       
        startAudioButton.SetActive(false);
        stopAudioButton.SetActive(true);
        Button button = startAudioButton.GetComponent<Button>();
        button.interactable = false;
        Button audioOff = stopAudioButton.GetComponent<Button>();
        audioOff.Select();
        audioOff.interactable = true;
        GameData.gameData.skip = true;
        if (GameData.gameData.finnish)
        {
            finnishAudio.Play();
            yield return new WaitForSeconds(finnishAudio.clip.length);
        }
        else
        {
            swedishAudio.Play();
            yield return new WaitForSeconds(swedishAudio.clip.length);

        }
        startAudioButton.SetActive(true);
        stopAudioButton.SetActive(false);
        button = startAudioButton.GetComponent<Button>();
        button.Select();
        button.interactable = true;
        audioOff = stopAudioButton.GetComponent<Button>();
        audioOff.interactable = false;

    }
}
