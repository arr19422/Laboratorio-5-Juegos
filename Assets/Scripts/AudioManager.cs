using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip jumpSFX;
    public AudioClip shootSFX;
    public AudioClip completeSFX;
    public AudioClip stepsSFX;
    public AudioClip targetSFX;
    public AudioClip pauseOnSFX;
    public AudioClip pauseOffSFX;


    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayJumpSFX()
    {
        if (jumpSFX) audioSource.PlayOneShot(jumpSFX);
    }

    public void PlayShootSFX()
    {
        if (shootSFX) audioSource.PlayOneShot(shootSFX);
    }

    public void PlayStepsSFX()
    {
        if (stepsSFX) audioSource.PlayOneShot(stepsSFX);
    }

    public void PlayCompleteSFX()
    {
        if (completeSFX) audioSource.PlayOneShot(completeSFX);
    }

    public void PlayTargetSFX()
    {
        if (targetSFX) audioSource.PlayOneShot(targetSFX);
    }

    public void PlayPauseOnSFX()
    {
        if (pauseOnSFX) audioSource.PlayOneShot(pauseOnSFX);
    }

    public void PlayPauseOffSFX()
    {
        if (pauseOffSFX) audioSource.PlayOneShot(pauseOffSFX);
    }
}
