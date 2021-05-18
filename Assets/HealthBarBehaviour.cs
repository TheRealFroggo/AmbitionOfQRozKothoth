using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    public Slider HealthSlider;
    public Vector3 Offset;

    private void Update()
    {
        HealthSlider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }

    public void SetHealthValue(int value)
    {
        HealthSlider.value = value;
    }

    public void SetMaxHealthValue(int value)
    {
        HealthSlider.maxValue = value;
    }
}
