using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIConfigManager : MonoBehaviour
{
    [SerializeField]
    Button backButton;

    [SerializeField]
    Slider bgmSlider;

    [SerializeField]
    Slider sfxSlider;

    // Start is called before the first frame update
    void Start()
    {

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
        SoundManager.Instance.sfxVolumeScale = bgmSlider.value;
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
