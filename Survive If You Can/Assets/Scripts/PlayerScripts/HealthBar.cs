using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    private float maxValue;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
        maxValue= health;
    }
    public void setHealth(float health)
    {
        slider.value = health;
        SetSliderColor(health);
    }

    private void SetSliderColor(float health)
    {
        if( health < (maxValue * 0.66))
        {
            slider.gameObject.transform.Find("Fill").GetComponent<Image>().color = Color.yellow;
        }
        if (health < (maxValue * 0.336))
        {
            slider.gameObject.transform.Find("Fill").GetComponent<Image>().color = Color.red;
        }
    }

}
