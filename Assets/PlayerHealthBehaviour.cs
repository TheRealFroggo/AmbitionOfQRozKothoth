using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBehaviour : MonoBehaviour
{
    private Slider HealthSlider;

    public void SetHealthValue(int value)
    {
        if (!HealthSlider)
        {
            HealthSlider = GetComponent<Slider>();
        }
        HealthSlider.value = value;
    }

    public void SetMaxHealthValue(int value)
    {
        if (!HealthSlider)
        {
            HealthSlider = GetComponent<Slider>();
        }
        HealthSlider.maxValue = value;
    }
}
