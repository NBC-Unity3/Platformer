using System;
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

    private bool masterMute = false;
    private bool bgmMute = false;
    private bool sfxMute = false;

    UIManager uiManager;

    private void Awake()
    {
        uiManager = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
        mixer.SetFloat("BGM", Mathf.Log10(PlayerPrefs.GetFloat("BGMVolume", 10.0f)) * 20);
        mixer.SetFloat("SFX", Mathf.Log10(PlayerPrefs.GetFloat("SFXVolume", 10.0f)) * 20);
        mixer.SetFloat("Master", Mathf.Log10(PlayerPrefs.GetFloat("MasterVolume", 10.0f)) * 20);

        bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
    }
    // Start is called before the first frame update
    void Start()
    {
        bgmSource.clip = bgmClip;
        bgmSource.Play();
        SetBGMVolume();
        SetSFXVolume();
        SetMasterVolume();
        if (PlayerPrefs.GetInt("MasterMute") == 1)
            masterMute = true;
        else if (PlayerPrefs.GetInt("MasterMute") == 0)
            masterMute = false;
        if (PlayerPrefs.GetInt("BGMMute") == 1)
            bgmMute = true;
        else if (PlayerPrefs.GetInt("BGMMute") == 0)
            bgmMute = false;
        if (PlayerPrefs.GetInt("SFXMute") == 1)
            sfxMute = true;
        else if (PlayerPrefs.GetInt("SFXMute") == 0)
            sfxMute = false;
        MuteMasterVolume();
        MuteBGMVolume();
        MuteSFXVolume();
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
        bgmMute = false;
        //PlayerPrefs.SetFloat("BGMVolume", volume);
        uiManager.ChangeBtnColor(uiManager.bgmMuteBtn, false);
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        mixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        sfxMute = false;
        //PlayerPrefs.SetFloat("SFXVolume", volume);
        uiManager.ChangeBtnColor(uiManager.sfxMuteBtn, false);
    }

    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        mixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        masterMute = false;
        //PlayerPrefs.SetFloat("MasterVolume", volume);
        uiManager.ChangeBtnColor(uiManager.masterMuteBtn, false);
    }

    public void MuteMasterVolume()
    {
        if (!masterMute)
        {
            uiManager.ChangeBtnColor(uiManager.masterMuteBtn, true);//빨간색
            PlayerPrefs.SetInt("MasterMute", 0);
            masterMute = true;
            mixer.SetFloat("Master", -80.0f);
        }
        else
        {
            uiManager.ChangeBtnColor(uiManager.masterMuteBtn, false);
            PlayerPrefs.SetInt("MasterMute", 1);
            masterMute = false;
            SetMasterVolume();
        }
    }
    public void MuteBGMVolume()
    {
        if (!bgmMute)
        {
            uiManager.ChangeBtnColor(uiManager.bgmMuteBtn, true);
            PlayerPrefs.SetInt("BGMMute", 0);
            bgmMute = true;
            mixer.SetFloat("BGM", -80.0f);
        }
        else
        {
            uiManager.ChangeBtnColor(uiManager.bgmMuteBtn, false);
            PlayerPrefs.SetInt("BGMMute", 1);
            bgmMute = false;
            SetBGMVolume();
        }
    }
    public void MuteSFXVolume()
    {
        if (!sfxMute)
        {
            uiManager.ChangeBtnColor(uiManager.sfxMuteBtn, true);
            PlayerPrefs.SetInt("SFXMute", 0);
            sfxMute = true;
            mixer.SetFloat("SFX", -80.0f);
        }
        else
        {
            uiManager.ChangeBtnColor(uiManager.sfxMuteBtn, false);
            PlayerPrefs.SetInt("SFXMute", 1);
            sfxMute = false;
            SetSFXVolume();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
