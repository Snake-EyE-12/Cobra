using Cobra.Audio;
using NaughtyAttributes;
using UnityEngine;

namespace Cobra
{
    public class WCT_AudioSliderTest : MonoBehaviour
    {
        [SerializeField] private AudioVolumeController av;

        [Button]
        public void Save()
        {
            av.Save();
        }

        [Button]
        public void Load()
        {
            av.LoadFromSave();
        }
    }
}
