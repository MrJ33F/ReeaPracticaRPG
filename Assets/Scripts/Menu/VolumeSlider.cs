using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    void Start()
    {
        Debug.Log("value");
        //Sliders.Add(_slider);
        //_slider.onValueChanged.AddListener(delegate { SoundManager.Instance.ChangeVolumen(_slider); });
        SoundManager.Instance.ChangeVolumen(_slider.value);
        _slider.onValueChanged.AddListener(val =>SoundManager.Instance.ChangeVolumen(val));
    }

}
