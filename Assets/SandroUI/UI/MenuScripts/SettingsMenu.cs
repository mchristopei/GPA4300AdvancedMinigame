﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    
    [SerializeField] private AudioMixer audioControl;
    [SerializeField] private Dropdown resolutionDropdown;
    Resolution[] resolutions;
    


     void Start()
     {
         resolutions = Screen.resolutions;

         resolutionDropdown.ClearOptions();

         List<string> options = new List<string>();


         int currentResolutionIndex = 0;
         for (int i = 0; i < resolutions.Length; i++)
         {
             string option = resolutions[i].width + "x" + resolutions[i].height;
             options.Add(option);

             if (resolutions[i].width == Screen.currentResolution.width && 
                 resolutions[i].height == Screen.currentResolution.height )
             {
                 currentResolutionIndex = i;
             }
         }

         resolutionDropdown.AddOptions(options);
         resolutionDropdown.value = currentResolutionIndex;
         resolutionDropdown.RefreshShownValue();
     } 



    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }


    public void SetVolume (float volume)
    {
        audioControl.SetFloat("AudioParam", volume);
    }


    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log("Graphics changed");
    }


    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }



}
