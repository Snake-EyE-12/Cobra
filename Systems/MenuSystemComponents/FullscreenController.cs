using UnityEngine;
using UnityEngine.UI;

namespace Cobra.GUI
{
    [RequireComponent(typeof(Toggle))]
    public class FullscreenController : MonoBehaviour, IMenuSettingSaveLoad
    {
        [Header("Fullscreen Control")]
        [SerializeField] private bool defaultValue = true;
        private bool lastValue;
        private const string prefsKey = "Fullscreen";
        
        [Header("References")]
        [SerializeField] private Toggle checkbox;
        private void Awake()
        {
            if(checkbox == null) checkbox = GetComponent<Toggle>();
            LoadFromSave();
        }
        
        public void SetFullscreen(bool full)
        {
            lastValue = full;
            Screen.fullScreen = full;
        }
        
        public void Save()
        {
            PlayerPrefs.SetInt(prefsKey, BoolToInt(lastValue));
        }

        public void LoadFromSave()
        {
            if (!PlayerPrefs.HasKey(prefsKey)) return;
            bool savedValue = IntToBool(PlayerPrefs.GetInt(prefsKey, BoolToInt(defaultValue)));
            SetFullscreen(savedValue);
            checkbox.isOn = savedValue;
        }

        public void LoadDefault()
        {
            SetFullscreen(defaultValue);
            checkbox.isOn = defaultValue;
        }

        private int BoolToInt(bool value)
        {
            return value ? 1 : 0;
        }

        private bool IntToBool(int value)
        {
            return value != 0;
        }
    }
}
