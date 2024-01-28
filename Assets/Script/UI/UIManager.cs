using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [Header ("UI")]
    [SerializeField] TextMeshProUGUI setTimeTxt;
    [SerializeField] Text rightTime;

    [SerializeField] GameObject time;
    [SerializeField] GameObject item;
    [SerializeField] GameObject settings;

    //public InputAction escapeControl;
    // Start is called before the first frame update

    private bool isPause = false;
    public float setTime;

    void Start()
    {
        setTime = 540.0f;
    }

    // Update is called once per frame

    void Update()
    {
        Console.WriteLine(setTime);
        if (setTime < 1260.0f)
        {
            setTime += Time.deltaTime;
            setTime += Time.deltaTime;
            setTime += Time.deltaTime;
            setTime += Time.deltaTime;
            setTime += Time.deltaTime;
            setTime += Time.deltaTime;
            setTime += Time.deltaTime;
            setTime += Time.deltaTime;
            setTime += Time.deltaTime;
        }

        else if (setTime > 1260.0f)
            Time.timeScale = 0.0f;
        setTimeTxt.text = Mathf.Floor(setTime / 60f).ToString().PadLeft(2, '0') + 
            " : " + 
            Mathf.Floor(setTime % 60f).ToString().PadLeft(2, '0');
        Console.WriteLine("onESC");
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

    public void goaldistance()
    {
        
    }

    public void CountDown()
    {

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

    public void getItem()
    {

    }
}
