using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.EventSystems.EventTrigger;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine.U2D;
using Unity.VisualScripting;
public class UIManager : MonoBehaviour
{
    [Header ("UI")]
    [SerializeField] TextMeshProUGUI setTimeTxt;
    [SerializeField] TextMeshProUGUI distanceTxt;
    [SerializeField] TextMeshProUGUI resultDistanceTxt;

    
    [SerializeField] GameObject item;
    [SerializeField] GameObject settings;
    [SerializeField] GameObject result;
    [SerializeField] GameObject goal;
    [SerializeField] GameObject player;

    private float distance;
    private float max_distance;

    private bool isPause = false;
    private bool isEnd = false;
    private float setTime;

    public Button masterMuteBtn, bgmMuteBtn, sfxMuteBtn;
    AudioManager audioManager;

    public TextMeshProUGUI targetText;
    private float delay = 0.125f;

    void Start()
    {
        Time.timeScale = 1.0f;
        setTime = 540.0f;
        max_distance = Vector3.Distance(player.transform.position, goal.transform.position);
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        //endResult("TimeOut");
    }

    void Update()
    {
        //거리UI 업데이트
        distance = Mathf.Ceil((max_distance - Vector3.Distance(player.transform.position, goal.transform.position)) * 100 / max_distance);
        distanceTxt.text = distance.ToString("F0") + "%";
        
        //시간UI 업데이트
        if (setTime < 1260.0f)
        {
            setTime += Time.deltaTime * 20;
        }

        else if (setTime >= 1260.0f && !isEnd)
        {
            Time.timeScale = 1f;
            if (!isEnd)
                endResult("TimeOut");
            isEnd = true;
        }
        setTimeTxt.text = Mathf.Floor(setTime / 60f).ToString().PadLeft(2, '0') + 
            ":" + 
            Mathf.Floor(setTime % 60f).ToString().PadLeft(2, '0');
        
        //ESC 키다운시 설정
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
            if (isPause)
            {
                Time.timeScale = 0.0f;
                settings.SetActive(true);
            }
            else
            {
                Time.timeScale = 1.0f;
                settings.SetActive(false);
            }
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }

    public void sceneChangeBtn(string scene)
    {
        audioManager.PlaySFX(audioManager.uiSelectClip);
        SceneManager.LoadScene(scene);
    }

    public void resumeBtn()
    {
        audioManager.PlaySFX(audioManager.uiSelectClip);
        isPause = false;
        Time.timeScale = 1.0f;
        settings.SetActive(false);
    }

    public void endResult(string ending)
    {
        player.IsDestroyed();
        result.SetActive(true);
        StartCoroutine(textPrint(delay, "??? : 크크크.. 오늘도 TIL을 쓰게 만들어야겠군!"));
        //resultTxt.text = "Press Any Key";
        //if (Input.anyKey)
        //    SceneManager.LoadScene("MainScene");
    }

    public void getItem()
    {
        //item.sprite 변경..
    }
    public void ChangeBtnColor(Button btn)
    {
        audioManager.PlaySFX(audioManager.uiSelectClip);
        if (btn.image.color == Color.red)
            btn.image.color = Color.white;
        else if (btn.image.color == Color.white)
            btn.image.color = Color.red;
    }
    IEnumerator textPrint(float delay, string text)
    {
        int count = 0;

        while (count != text.Length)
        {
            if (count < text.Length)
            {
                targetText.text += text[count].ToString();
                count++;
            }

            yield return new WaitForSeconds(delay);
        }
    }
}
