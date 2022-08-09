using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderEvent : MonoBehaviour
{
    public Slider slider;

    public void Event()
    {
        SoundManager.Instance.ChangeVolumen(slider.value);
    }

}
