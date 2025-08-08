using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;


namespace Cobra
{ 
    public class SettingsController : MonoBehaviour
    {
        public AudioMixer mixer;

        public TMP_Dropdown resolutionDropdown;

        public SettingsAsset settings;
         
        public bool only16By9 = false;
        static List<Resolution> res;
        static List<string> options = new List<string>();

        void Start()
        {
            if (options.Count > 0)
            {
                resolutionDropdown.ClearOptions();
                resolutionDropdown.AddOptions(options);
                resolutionDropdown.value = settings.screenResolution;
                resolutionDropdown.RefreshShownValue();

                return;
            }

            res = Screen.resolutions.ToList();
            resolutionDropdown.ClearOptions();
            List<Resolution> newRes = new List<Resolution>();
            int currentResIndex = -1;
            int newResInd = 0;
            int closestDif = int.MaxValue;
            string prev = "";

            for (int i = 0; i < res.Count; i++)
            {
                string check = res[i].width + "x" + res[i].height;
                float aspect = (float)res[i].width / res[i].height;
                if (only16By9 && (check == prev || Mathf.Abs(aspect - (16f / 9f)) > 0.01f)) continue;

                string option = check;
                prev = check;
                options.Add(option);
                newRes.Add(res[i]);

                int dif = Mathf.Abs(Screen.currentResolution.width - newRes[newResInd].width) +
                    Mathf.Abs(Screen.currentResolution.height - newRes[newResInd].height);

                if (dif < closestDif)
                {
                    closestDif = dif;
                    currentResIndex = newResInd;
                }
                newResInd++;
            }

            if (currentResIndex == -1) currentResIndex = 4;

            res = newRes;
            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResIndex;
            resolutionDropdown.RefreshShownValue();
            SetResolution(currentResIndex);
            settings.screenResolution = currentResIndex;
        }

        public void SetMasterVolume(float volume)
        {
            if (volume == -45) volume = -80;
            mixer.SetFloat("MasterVolume", volume);
        }

        public void SetMusicVolume(float volume)
        {
            if (volume == -45) volume = -80;
            mixer.SetFloat("MusicVolume", volume);
        }

        public void SetSFXVolume(float volume)
        {
            if (volume == -45) volume = -80;
            mixer.SetFloat("SFXVolume", volume);
        }

        public void SetResolution(int resIndex)
        {
            Screen.SetResolution(res[resIndex].width, res[resIndex].height, Screen.fullScreen);
        }

        public void SetFullScreen(bool isFullScreen)
        {
            Screen.fullScreen = isFullScreen;
        }


        public void SaveSettings()
        {
            mixer.GetFloat("MasterVolume", out settings.masterVolume);
            mixer.GetFloat("MusicVolume", out settings.musicVolume);
            mixer.GetFloat("SFXVolume", out settings.sfxVolume);
            settings.isFullScreen = Screen.fullScreen;
            settings.screenResolution = resolutionDropdown.value;
        }

        public void ApplyData()
        {
            //load in the sound data
            foreach (var slider in transform.Find("Settings").GetComponentsInChildren<Slider>())
            {
                if (slider.name == "MasterVolume") slider.value = settings.masterVolume;
                else if (slider.name == "MusicVolume") slider.value = settings.musicVolume;
                else slider.value = settings.sfxVolume;
            }

            //load in the toggle data
            foreach (var toggle in transform.Find("Settings").GetComponentsInChildren<Toggle>())
            {
                toggle.isOn = settings.isFullScreen;
            }


            //load in screen resolution
            resolutionDropdown.value = settings.screenResolution;
        }

        public void OnBackPressed()
        {
            this.gameObject.SetActive(false);
        }
    }
}
