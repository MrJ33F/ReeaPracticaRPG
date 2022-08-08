using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Sliders
{
    public static List<Slider> sliders = new();

    public static void Add(Slider newSlider)
    {
        sliders.Add(newSlider);
        //Debug.Log(sliders);
    }

    public static void Change(float newValue)
    {
        foreach(Slider s in sliders)
        {
            s.value = newValue;
        }
        //Debug.Log(sliders);
    }

}
