using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;

    private void Start(){
        if(PlayerPrefs.HasKey("musicVolume")){
            LoadVolume();
        }
        else{
            SetMusicVolume();
        }
    }

    public void SetMusicVolume(){
        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    private void LoadVolume(){
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");

        SetMusicVolume();
    }

    public void MuteMusic(){
        float novolume = 0f;
        myMixer.SetFloat("music", Mathf.Log10(Mathf.Max(novolume, 0.0001f)) * 20);
        PlayerPrefs.SetFloat("musicVolume", novolume);
    }

    
}
 