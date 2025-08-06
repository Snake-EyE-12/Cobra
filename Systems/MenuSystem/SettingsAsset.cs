using System.Collections.Generic;
using UnityEngine;

namespace Cobra
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Scriptable Objects/Settings")]
    public class SettingsAsset : ScriptableObject
    {
        public float masterVolume;
        public float musicVolume;
        public float sfxVolume;

        public int screenResolution;

        public bool isFullScreen;
    }
}
