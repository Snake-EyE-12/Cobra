using TMPro;
using UnityEngine;

namespace Cobra.GUI
{
    [RequireComponent(typeof(TMP_Dropdown))]
    public class GraphicsQualityController : MonoBehaviour, IMenuSettingSaveLoad
    {
        [Header("Graphics Control")]
        [SerializeField, Range(0, 2)] private int defaultValue = 2;
        private int lastValue;
        [SerializeField] private bool applyExpensively = true;
        private const string prefsKey = "GraphicsQualityLevel";

        [Header("References")]
        [SerializeField] private TMP_Dropdown dropDown;
        private void Awake()
        {
            if(dropDown == null) dropDown = GetComponent<TMP_Dropdown>();
            LoadDefault();
        }

        public void SetQuality(int level)
        {
            lastValue = level;
            QualitySettings.SetQualityLevel(level, applyExpensively);
        }
        public void Save()
        {
            PlayerPrefs.SetInt(prefsKey, lastValue);
        }

        public void LoadFromSave()
        {
            if (!PlayerPrefs.HasKey(prefsKey)) return;
            int savedValue = PlayerPrefs.GetInt(prefsKey, defaultValue);
            SetQuality(savedValue);
            RefreshValue(savedValue);
        }

        public void LoadDefault()
        {
            SetQuality(defaultValue);
            RefreshValue(defaultValue);
        }

        private void RefreshValue(int value)
        {
            dropDown.value = value;
            dropDown.RefreshShownValue();
        }
    }
}
