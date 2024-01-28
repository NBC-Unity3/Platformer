using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource bgmSource;
    [SerializeField] AudioSource sfxCource;

    public AudioClip bgmClip;
    public AudioClip titleClip;
    public AudioClip jumpClip;
    public AudioClip throwClip;
    public AudioClip uiSelectClip;
    public AudioClip walkClip;


    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider masterSlider;


    // Start is called before the first frame update
    void Start()
    {
        bgmSource.clip = bgmClip;
        bgmSource.Play();
    }

    //isJump()등에서 액세스 하게끔 pulibc화
    public void PlaySFX(AudioClip clip)
    {
        if (clip == walkClip && sfxCource.isPlaying)
                return;
        sfxCource.PlayOneShot(clip);
    }

    public void SetBGMVolume()
    {
        float volume = bgmSlider.value;
        mixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
    }
    
    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        mixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        mixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
