using Cobra.GUI;
using Cobra.Utilities;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Cobra.Audio
{
    [RequireComponent(typeof(Slider))]
    public class AudioVolumeController : MonoBehaviour, IMenuSettingSaveLoad
    {
        [Header("Audio Control")]
        [SerializeField] private AudioMixer mixer;
        [SerializeField] private string groupName = "Master";
        [SerializeField, Range(0, 1)] private float defaultValue = 1.0f;
        private const string VOLUME = "Volume";
        private float lastSliderValue = 1;
        public void SetVolume(float volume)
        {
            lastSliderValue = volume;
            mixer.SetFloat(AppendVolume(groupName), DecibelNormalize(volume));
        }

        private string AppendVolume(string input)
        {
            if (input.EndsWith(VOLUME)) return input;
            return input + VOLUME;
        }

        private float DecibelNormalize(float sliderValue)
        {
            return MathUtils.LinearToDecibels(sliderValue);
        }

        public void Save()
        {
            PlayerPrefs.SetFloat(AppendVolume(groupName), lastSliderValue);
        }

        [Header("References")]
        [SerializeField] private Slider slider;

        private void Awake()
        {
            if(slider == null) slider = GetComponent<Slider>();
            LoadDefault();
        }


        public void LoadFromSave()
        {
            if (!PlayerPrefs.HasKey(AppendVolume(groupName))) return;
            float savedValue = PlayerPrefs.GetFloat(AppendVolume(groupName), defaultValue);
            SetVolume(savedValue);
            slider.value = savedValue;
        }

        public void LoadDefault()
        {
            SetVolume(defaultValue);
            slider.value = defaultValue;
        }
    }
}
