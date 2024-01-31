using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIConfigManager : MonoBehaviour
{
    [SerializeField]
    Slider bgmSlider;

    [SerializeField]
    Slider sfxSlider;

    [SerializeField]
    Slider masterSlider;

    [SerializeField]
    Button bgmMuteButton;

    [SerializeField]
    Button sfxMuteButton;

    [SerializeField]
    Button masterMuteButton;

    private bool masterMute = false;
    private bool bgmMute = false;
    private bool sfxMute = false;

    // Start is called before the first frame update
    void Start()
    {
        bgmSlider.value = SoundManager.Instance.bgmVolumeScale;
        sfxSlider.value = SoundManager.Instance.sfxVolumeScale;
        masterSlider.value = SoundManager.Instance.masterVolumeScale;

        masterMute = PlayerPrefs.GetInt("MasterMute", 0) == 1;
        bgmMute =  PlayerPrefs.GetInt("BgmMute", 0) == 1;
        sfxMute = PlayerPrefs.GetInt("SfxMute", 0) == 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BackButtion()
    {
        SoundManager.Instance.PlaySFX("UISelect");
        this.gameObject.SetActive(false);
    }

    public void OnBGMSliderRelease() 
    {
        SoundManager.Instance.PlaySFX("UISelect");
        SoundManager.Instance.bgmVolumeScale = bgmSlider.value;
    }

    public void OnSFXSliderRelease() 
    {
        SoundManager.Instance.PlaySFX("UISelect");
        SoundManager.Instance.sfxVolumeScale = sfxSlider.value;
    }

    public void OnMasterSliderRelease() 
    {
        SoundManager.Instance.PlaySFX("UISelect");
        SoundManager.Instance.masterVolumeScale = masterSlider.value;
    }

    public void MuteMasterVolume()
    {
        if (masterMute == false)
        {
            masterMuteButton.image.color = Color.red;
            PlayerPrefs.SetInt("MasterMute", 1);
            masterMute = true;
            if(!bgmMute) { MuteBGMVolume(); }
            if(!sfxMute) { MuteSFXVolume(); }
        }
        else
        {
            masterMuteButton.image.color = Color.white;
            PlayerPrefs.SetInt("MasterMute", 0);
            masterMute = false;
            if (bgmMute) { MuteBGMVolume(); }
            if (sfxMute) { MuteSFXVolume(); }
        }
        SoundManager.Instance.SetMasterMute(masterMute);
    }
    public void MuteBGMVolume()
    {
        if (bgmMute == false)
        {
            bgmMuteButton.image.color = Color.red;
            PlayerPrefs.SetInt("BgmMute", 1);
            bgmMute = true;
        }
        else
        {
            bgmMuteButton.image.color = Color.white;
            PlayerPrefs.SetInt("BgmMute", 0);
            bgmMute = false;
        }
        SoundManager.Instance.SetBGMMute(bgmMute);
    }
    public void MuteSFXVolume()
    {
        if (sfxMute == false)
        {
            sfxMuteButton.image.color = Color.red;
            PlayerPrefs.SetInt("SfxMute", 1);
            sfxMute = true;
        }
        else
        {
            sfxMuteButton.image.color = Color.white;
            PlayerPrefs.SetInt("SfxMute", 0);
            sfxMute = false;
        }
        SoundManager.Instance.SetSFXMute(sfxMute);
    }

    private void OnEnable()
    {
        // timeScale ?
    }

    private void OnDisable()
    {
        // timeScale ?
    }
}
