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
    private float setTime;

    public Button masterMuteBtn, bgmMuteBtn, sfxMuteBtn;

    void Start()
    {
        Time.timeScale = 1.0f;
        setTime = 540.0f;
        max_distance = Vector3.Distance(player.transform.position, goal.transform.position);
    }

    void Update()
    {
        //�Ÿ�UI ������Ʈ
        distance = Mathf.Ceil((max_distance - Vector3.Distance(player.transform.position, goal.transform.position)) * 100 / max_distance);
        distanceTxt.text = distance.ToString("F0") + "%";
        
        //�ð�UI ������Ʈ
        if (setTime < 1260.0f)
        {
            setTime += Time.deltaTime * 20;
        }

        else if (setTime > 1260.0f)
        {
            Time.timeScale = 0.0f;
            isDie();
        }
        setTimeTxt.text = Mathf.Floor(setTime / 60f).ToString().PadLeft(2, '0') + 
            ":" + 
            Mathf.Floor(setTime % 60f).ToString().PadLeft(2, '0');
        
        //ESC Ű�ٿ�� ����
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
        SceneManager.LoadScene(scene);
    }

    public void resumeBtn()
    {
        isPause = false;
        Time.timeScale = 1.0f;
        settings.SetActive(false);
    }

    public void isDie()
    {
        result.SetActive(true);
    }

    public void getItem()
    {
        //item.sprite ����..
    }
    public void ChangeBtnColor(Button btn)
    {
        if (btn.image.color == Color.red)
            btn.image.color = Color.white;
        else if (btn.image.color == Color.white)
            btn.image.color = Color.red;
    }
}