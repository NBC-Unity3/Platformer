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
        // todo : SFX 넣기
        titleSceneManager.EnterGame();
        titleSceneManager.DisableTitleUI();
    }

    public void OnClickSettings() 
    {
        // todo : SFX 넣기
        titleSceneManager.DisableTitleUI();
        // todo : 설정창 띄우기
    }

    public void OnClickExit() 
    {
        // todo : SFX 넣기

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }
}
