using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixerBackground;

    public AudioMixer audioMixerSFX;

    public Slider backgroundSlider;

    public Slider sfxSlider;

    public Toggle toggleFullScreen;

    public Dropdown resolutionDropdown;

    public SOOptionSettings optionSettings;

    private bool fullScreen = true;

    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length ; i++)
        {
            string option = resolutions[i].width + " x "+ resolutions[i].height;
            options.Add(option);

            if(optionSettings.resolutionIndex == 0 && resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                optionSettings.resolutionIndex = i;
            }
        }

       toggleFullScreen.isOn = optionSettings.fullscreen;

       resolutionDropdown.AddOptions(options);
       resolutionDropdown.value = optionSettings.resolutionIndex;
       resolutionDropdown.RefreshShownValue();
 
       audioMixerBackground.SetFloat("volumeBackground", Mathf.Log10(optionSettings.volumeBackground) * 20);
       audioMixerSFX.SetFloat("volumeSFX", Mathf.Log10(optionSettings.volumeSFX) * 20);
       backgroundSlider.value = optionSettings.volumeBackground;
       sfxSlider.value = optionSettings.volumeSFX;
        

    }   

    public void SetResolution(int resoluitonIndex)
    {
        Resolution resolution = resolutions[resoluitonIndex];
        optionSettings.resolutionIndex = resoluitonIndex;
        Screen.SetResolution(resolution.width, resolution.height, optionSettings.fullscreen);
    }

    public void SetVolumeBackground(float volume){
        optionSettings.volumeBackground = volume;
        audioMixerBackground.SetFloat("volumeBackground", Mathf.Log10(volume) *20);
    }

    public void SetVolumeSFX(float volume)
    {
        optionSettings.volumeSFX = volume;
        audioMixerSFX.SetFloat("volumeSFX", Mathf.Log10(volume) * 20);
    }

    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen){
        optionSettings.fullscreen = isFullScreen;
        
    }
}
