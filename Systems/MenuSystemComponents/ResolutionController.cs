using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace Cobra.GUI
{
    [RequireComponent(typeof(TMP_Dropdown))]
    public class ResolutionController : MonoBehaviour, IMenuSettingSaveLoad
    {
        [Header("Resolution Control")]
        private int defaultValue = 0;
        private int lastValue;
        private const string prefsKey = "ResolutionIndex";

        [Header("References")]
        [SerializeField] private TMP_Dropdown dropDown;
        
        private Resolution[] resolutions;
        private void Awake()
        {
            if(dropDown == null) dropDown = GetComponent<TMP_Dropdown>();
            PrepareResolutions();
            LoadDefault();
        }

        private void PrepareResolutions()
        {
            resolutions = Screen.resolutions;
            dropDown.ClearOptions();
            List<string> options = new();
            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);

                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                    defaultValue = i;
                }
            }
            dropDown.AddOptions(options);
        }

        public void SetResolution(int index)
        {
            lastValue = index;
            Resolution resolution = resolutions[index];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }
        public void Save()
        {
            PlayerPrefs.SetInt(prefsKey, lastValue);
        }

        public void LoadFromSave()
        {
            if (!PlayerPrefs.HasKey(prefsKey)) return;
            int savedValue = PlayerPrefs.GetInt(prefsKey, defaultValue);
            SetResolution(savedValue);
            RefreshValue(savedValue);
        }

        public void LoadDefault()
        {
            SetResolution(defaultValue);
            RefreshValue(defaultValue);
        }
        
        private void RefreshValue(int value)
        {
            dropDown.value = value;
            dropDown.RefreshShownValue();
        }
    }
}