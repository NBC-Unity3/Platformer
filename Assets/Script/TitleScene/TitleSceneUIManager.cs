using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneUIManager : MonoBehaviour
{
    [SerializeField]
    TitleSceneManager titleSceneManager;

    public void OnClickEnter() 
    {
        SoundManager.Instance.PlaySFX("UISelect");
        titleSceneManager.EnterGame();
        titleSceneManager.DisableTitleUI();
    }

    public void OnClickSettings() 
    {
        SoundManager.Instance.PlaySFX("UISelect");
        titleSceneManager.DisableTitleUI();
        titleSceneManager.EnableConfigUI();
    }

    public void OnClickExit() 
    {
        SoundManager.Instance.PlaySFX("UISelect");

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }
}
