using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Content;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.VFX;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();

                if (instance == null)
                {
                    instance = new GameObject("SoundManager").AddComponent<SoundManager>();
                }
            }

            return instance;
        }
    }

    [SerializeField]
    AudioSource bgmSource;

    [SerializeField]
    AudioClip bgmClip;

    [SerializeField]
    AudioSource sfxSource;

    [SerializeField]
    int MAX_SFX_CACHE_SIZE = 10;

    List<(string, AudioClip)> sfxList;
    int sfxEraseIndex = 0;

    List<string> bgmNameCache = new List<string>();
    List<string> sfxNameCache = new List<string>();

    const string RESOURCES_SOUND_PATH = "Sound/";

    string BGM_PATH { get { return RESOURCES_SOUND_PATH + "BGM/"; } }
    string SFX_PATH { get { return RESOURCES_SOUND_PATH + "SFX/"; } }

    private float _bgmVolumeScale = 1;
    public float bgmVolumeScale { get { return _bgmVolumeScale * masterVolumeScale; } set {
            _bgmVolumeScale = value;
            PlayerPrefs.SetFloat("BGMVolume", bgmVolumeScale);
            bgmSource.volume = _bgmVolumeScale * masterVolumeScale;
        } }


    private float _sfxVolumeScale = 1;
    public float sfxVolumeScale { get { return _sfxVolumeScale * masterVolumeScale; } set {
            _sfxVolumeScale = value;
            PlayerPrefs.SetFloat("SFXVolume", _sfxVolumeScale);
            sfxSource.volume = _sfxVolumeScale * masterVolumeScale;
        } }

    private float _masterVolumeScale = 1;
    public float masterVolumeScale
    {
        get { return _masterVolumeScale; }
        set
        {
            _masterVolumeScale = value;
            PlayerPrefs.SetFloat("MasterVolume", _masterVolumeScale);
            bgmSource.volume = _bgmVolumeScale * _masterVolumeScale;
            sfxSource.volume = _sfxVolumeScale * _masterVolumeScale;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        CachingNames();

        _bgmVolumeScale = PlayerPrefs.GetFloat("BGMVolume");
        _sfxVolumeScale = PlayerPrefs.GetFloat("SFXVolume");
        _masterVolumeScale = PlayerPrefs.GetFloat("MasterVolume");

        sfxList = new List<(string, AudioClip)>(MAX_SFX_CACHE_SIZE);

        if (GameObject.Find("BGMPlayer") == null) 
        {
            bgmSource = new GameObject("BGMPlayer").AddComponent<AudioSource>();
            bgmSource.loop = true;
            bgmSource.transform.parent = transform;
        }

        if (GameObject.Find("SFXPlayer") == null) 
        {
            sfxSource = new GameObject("SFXPlayer").AddComponent<AudioSource>();
            sfxSource.transform.parent = transform;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        // PlayBGM("Title");
    }

    public void PlayBGM(string name) 
    {
        if(!bgmNameCache.Contains(name)) 
        {
            Debug.LogError("BGM name not found!");
            return;
        }

        bgmSource?.Stop();
        bgmClip = Resources.Load<AudioClip>(BGM_PATH + name);
        bgmSource.clip = bgmClip;
        bgmSource.Play();
    }

    public void PauseBGM() 
    {
        bgmSource?.Pause();
    }

    public void ResumeBGM() 
    {
        bgmSource.UnPause();
    }

    public void PlaySFX(string name) 
    {
        if(!sfxNameCache.Contains(name)) 
        {
            Debug.LogError("SFX name not found!");
            return;
        }

        if(!IsSFXListContains(name)) 
        {
            LoadSFXOnList(name);
        }

        sfxSource.PlayOneShot(GetAudioClipFromSFXList(name));
    }

    void LoadSFXOnList(string name) 
    {
        if(sfxList.Count == MAX_SFX_CACHE_SIZE) 
        {
            sfxList.RemoveAt(sfxEraseIndex++);
            sfxEraseIndex %= MAX_SFX_CACHE_SIZE;
        }
        sfxList.Add((name, Resources.Load<AudioClip>(SFX_PATH + name)));
    }

    AudioClip GetAudioClipFromSFXList(string name) 
    {
        foreach (var tuple in sfxList)
        {
            if (tuple.Item1 == name)
                return tuple.Item2;
        }
        return null;
    }

    bool IsSFXListContains(string name) 
    {
        foreach(var tuple in sfxList) 
        {
            if (tuple.Item1 == name)
                return true;
        }
        return false;
    }

    void CachingNames() 
    {
        foreach(string s in AssetDatabase.GetAssetPathsFromAssetBundle("bgm")) 
        {
            string name = s.Substring(s.LastIndexOf("/")+1, s.LastIndexOf(".") - (s.LastIndexOf("/") + 1));
            bgmNameCache.Add(name);
            Debug.Log("Add BGM : " + name);
        }

        // bgmNameCache.OrderBy(name => name);

        foreach (string s in AssetDatabase.GetAssetPathsFromAssetBundle("sfx"))
        {
            string name = s.Substring(s.LastIndexOf("/") + 1, s.LastIndexOf(".") - (s.LastIndexOf("/") + 1));
            sfxNameCache.Add(name);
            Debug.Log("Add SFX : " + name);
        }

        // sfxNameCache.OrderBy(name => name);
    }

    public void ClearSFXList() 
    {
        sfxList.Clear();
    }

    public void SetBGMMute(bool mute) 
    {
        bgmSource.mute = mute;
    }

    public void SetSFXMute(bool mute) 
    {
        sfxSource.mute = mute;
    }

    public void SetMasterMute(bool mute) 
    {
        SetBGMMute(mute);
        SetSFXMute(mute);
    }
}
