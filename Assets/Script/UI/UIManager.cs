using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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

    public Text targetText;
    public float TimeScaile;
    private float delay = 0.125f;

    void Start()
    {
        Time.timeScale = 1.0f;
        setTime = 540.0f;
        max_distance = Vector3.Distance(player.transform.position, goal.transform.position);

        player.GetComponent<PlayerColntroller>().OnPickUpItem += getItem;
        player.GetComponent<PlayerColntroller>().OnConsumeItem += consumeItem;
        this.item.GetComponent<Image>().enabled = false;

        SoundManager.Instance.PlayBGM("Game");
    }

    void Update()
    {
        //거리UI 업데이트
        distance = Mathf.Ceil((max_distance - Vector3.Distance(player.transform.position, goal.transform.position)) * 100 / max_distance);
        distanceTxt.text = distance.ToString("F0") + "%";
        
        //시간UI 업데이트
        if (setTime < 1260.0f)
        {
            setTime += Time.deltaTime * TimeScaile;
        }

        else if (setTime >= 1260.0f && !isEnd)
        {
            Time.timeScale = 1f;
            if (!isEnd)
                endResult("퇴실버튼을 못눌러서 매니저님이 찾아왔다");
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
                Time.fixedDeltaTime = Single.MaxValue;
                settings.SetActive(true);
            }
            else
            {
                Time.timeScale = 1.0f;
                Time.fixedDeltaTime = 0.02f;
                settings.SetActive(false);
            }
            // Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }

    public void sceneChangeBtn(string scene)
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f;
        SoundManager.Instance.PlaySFX("UISelect");
        SceneManager.LoadScene(scene);
    }

    public void resumeBtn()
    {
        SoundManager.Instance.PlaySFX("Walk");
        isPause = false;
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f;
        settings.SetActive(false);
    }

    public void endResult(string endingComment)
    {
        if (!isEnd)
        {
            result.SetActive(true);
            StartCoroutine(textPrint(delay, endingComment));
        }
        isEnd = true;
    }

    public void getItem(Item item)
    {
        this.item.GetComponent<Image>().enabled = true;
        this.item.GetComponent<Image>().sprite = item.itemSprite.sprite;
    }


    public void consumeItem() 
    {
        this.item.GetComponent<Image>().enabled = false;
        this.item.GetComponent<Image>().sprite = null;
    }

    public void ChangeBtnColor(Button btn, bool mute)
    {
        if (mute == false)
            btn.image.color = Color.white;
        else if (mute == true)
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
