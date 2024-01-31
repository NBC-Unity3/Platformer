using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField]
    Transform playerCharacter;

    [SerializeField]
    Transform blackGradient;

    [SerializeField]
    float playerMoveSpeed = 1.0f;

    [SerializeField]
    float gradientMoveSpeed = 1.0f;

    [SerializeField]
    HorizontalGridScroller horizontalGridScroller1;

    [SerializeField]
    HorizontalGridScroller horizontalGridScroller2;

    [SerializeField]
    GameObject titleUI;

    [SerializeField]
    GameObject configUI;

    private void Start()
    {
        // todo : BGM 켜기
        SoundManager.Instance.PlayBGM("Title");
    }


    public void EnterGame()
    {
        horizontalGridScroller1.scrollSpeed = 0;
        horizontalGridScroller2.scrollSpeed = 0;

        SoundManager.Instance.PauseBGM();

        StartCoroutine("Entering");
    }

    IEnumerator Entering()
    {
        float time = 0;
        while (time < 1.9f)
        {
            playerCharacter.transform.position += new Vector3(playerMoveSpeed * Time.deltaTime, 0, 0);
            blackGradient.transform.position -= new Vector3(gradientMoveSpeed * Time.deltaTime, 0, 0);
            time += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene("MainScene");
    }

    public void DisableTitleUI()
    {
        titleUI.SetActive(false);
    }

    public void EnableTitleUI()
    {
        titleUI.SetActive(true);
    }

    public void DisableConfigUI()
    {
        configUI.SetActive(false);
    }

    public void EnableConfigUI() 
    {
        configUI.SetActive(true);
    }
}
