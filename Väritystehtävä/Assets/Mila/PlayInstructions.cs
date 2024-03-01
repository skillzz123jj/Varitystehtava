using System.Collections;
using TMPro;
using UnityEngine;

public class PlayInstructions : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] TMP_Text buttonText;

    bool isAudioPlaying = false;

    public void Play()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return;
        }
            if (!isAudioPlaying)
            {
                StartCoroutine(PlayAudio());
            }
            else
            {
                StopCoroutine(PlayAudio());
                audioSource.Stop();
                isAudioPlaying = false;
                buttonText.text = "Kuuntele";
            }
        
    }

    public IEnumerator PlayAudio()
    {
        isAudioPlaying = true;
        audioSource.Play();
        buttonText.text = "Pysäytä";
        yield return new WaitForSeconds(audioSource.clip.length);
        buttonText.text = "Kuuntele";
        isAudioPlaying = false;
    }
}
