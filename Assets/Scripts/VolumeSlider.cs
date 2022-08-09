using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    void Awake()
    {
        Sliders.Add(_slider);
    }

    void Start()
    {
        Sliders.Add(_slider);
        SoundManager.Instance.ChangeVolumen(_slider.value);
        _slider.onValueChanged.AddListener(val =>SoundManager.Instance.ChangeVolumen(val));
    }

}
