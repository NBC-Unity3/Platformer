using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class UIManager : MonoBehaviour
{
    [Header ("UI")]
    [SerializeField] TextMeshProUGUI leftTime;
    [SerializeField] Text rightTime;

    [SerializeField] GameObject time;
    [SerializeField] GameObject item;
    [SerializeField] GameObject settings;

    //public InputAction escapeControl;
    // Start is called before the first frame update

    private bool isPause = false;

    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        
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
}
