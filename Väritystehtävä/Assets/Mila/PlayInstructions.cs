using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInstructions : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {

        StartCoroutine(PlayAudio());
      
    }

    public IEnumerator PlayAudio()
    {
        animator.SetBool("Instruction", true);
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        animator.SetBool("Instruction", false);

    }
}
