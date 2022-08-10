using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

    [SerializeField] private AudioSource musicSource;

    void Awake()
    {
        Debug.Log("SoundManager");
        if(Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy(gameObject);
        }
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0);
            Load();
        }
        else
        {
            Debug.Log("load");
            Load();
        }
    }

    public void ChangeVolumen(float value)
    {
        Debug.Log(value);
        Debug.Log("Volume changed");
        AudioListener.volume = value;
        Save(value);
    }
    
    public void Load()
    {
        //volumeSliderr.value = PlayerPrefs.GetFloat("musicVolume");
    }

    public void Save(float value)
    {
        //Sliders.Change(PlayerPrefs.GetFloat("musicVolume"));
        PlayerPrefs.SetFloat("musicVolume", value);
    }

}
