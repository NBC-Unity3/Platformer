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

    // Start is called before the first frame update
    void Start()
    {
        bgmSlider.value = SoundManager.Instance.bgmVolumeScale;
        sfxSlider.value = SoundManager.Instance.sfxVolumeScale;
        masterSlider.value = SoundManager.Instance.masterVolumeScale;
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

    private void OnEnable()
    {
        // timeScale ?
    }

    private void OnDisable()
    {
        // timeScale ?
    }
}
