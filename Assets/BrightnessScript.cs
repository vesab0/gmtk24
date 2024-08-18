using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessScript : MonoBehaviour
{
   public Slider slider;
   public float sliderValue;
   public Image panelBrightness;

    private void Start(){
        slider.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        float adjustedValue = 0.8f - slider.value;
        panelBrightness.color= new Color(panelBrightness.color.r,panelBrightness.color.g, panelBrightness.color.b, adjustedValue);
    }


   public void ChangeSlider(float value){
        sliderValue=value;
        float adjustedValue = 0.8f - slider.value;
        PlayerPrefs.SetFloat("brillo", sliderValue);
        panelBrightness.color= new Color(panelBrightness.color.r, panelBrightness.color.g, panelBrightness.color.b, adjustedValue);
   }
}
