using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

namespace Cobra.Audio {
    [Serializable]
    public class SoundDataComplex : SoundDataProvider {
        [SerializeField] private AudioClip clip;
        [SerializeField] private AudioMixerGroup mixerGroup;
        [SerializeField] private bool loop;
        [SerializeField] private bool playOnAwake;
        [SerializeField] private bool frequentSound;
        
        [SerializeField] private bool mute;
        [SerializeField] private bool bypassEffects;
        [SerializeField] private bool bypassListenerEffects;
        [SerializeField] private bool bypassReverbZones;
        
        [SerializeField, Range(0, 256)] private int priority = 128;
        [SerializeField, MinMaxSlider(0, 1)] private Vector2 volumeRange = new Vector2(1, 1);
        [SerializeField, MinMaxSlider(-3, 3)] private Vector2 pitchRange = new Vector2(1, 1);
        [SerializeField, Range(-1, 1)] private float panStereo;
        [SerializeField, Range(0, 1)] private float spatialBlend;
        [SerializeField, Range(0, 1.1f)] private float reverbZoneMix = 1f;
        [SerializeField, Range(0, 5)] private float dopplerLevel = 1f;
        [SerializeField, Range(0, 360)] private float spread;
        
        [SerializeField, Min(0)] private float minDistance = 1f;
        [SerializeField, Min(0.01f)] private float maxDistance = 500f;
        
        [SerializeField] private bool ignoreListenerVolume;
        [SerializeField] private bool ignoreListenerPause;
        
        [SerializeField] private AudioRolloffMode rolloffMode = AudioRolloffMode.Logarithmic;
        public AudioClip Clip { get => clip; }
        public AudioMixerGroup MixerGroup { get => mixerGroup; }
        public float Volume { get => Random.Range(volumeRange.x, volumeRange.y); }
        public float Pitch { get => Random.Range(pitchRange.x, pitchRange.y); }
        public bool Loop { get => loop; }
        public bool PlayOnAwake { get => playOnAwake; }
        public bool FrequentSound { get => frequentSound; }
        public bool Mute { get => mute; }
        public bool BypassEffects { get => bypassEffects; }
        public bool BypassListenerEffects { get => bypassListenerEffects; }
        public bool BypassReverbZones { get => bypassReverbZones; }
        public int Priority { get => priority; }
        public float PanStereo { get => panStereo; }
        public float SpatialBlend { get => spatialBlend; }
        public float ReverbZoneMix { get => reverbZoneMix; }
        public float DopplerLevel { get => dopplerLevel; }
        public float Spread { get => spread; }
        public float MinDistance { get => minDistance; }
        public float MaxDistance { get => maxDistance; }
        public bool IgnoreListenerVolume { get => ignoreListenerVolume; }
        public bool IgnoreListenerPause { get => ignoreListenerPause; }
        public AudioRolloffMode RolloffMode { get => rolloffMode; }
    }

    public interface SoundDataProvider
    {
        public AudioClip Clip { get; }
        public AudioMixerGroup MixerGroup { get; }
        public float Volume { get; }
        public float Pitch { get; }
        public bool Loop { get; }
        public bool PlayOnAwake { get; }
        public bool FrequentSound { get; }
        
        public bool Mute { get; }
        public bool BypassEffects { get; }
        public bool BypassListenerEffects { get; }
        public bool BypassReverbZones { get; }
        
        public int Priority { get; }
        public float PanStereo { get; }
        public float SpatialBlend { get; }
        public float ReverbZoneMix { get; }
        public float DopplerLevel { get; }
        public float Spread { get; }
        
        public float MinDistance { get; }
        public float MaxDistance { get; }
        
        public bool IgnoreListenerVolume { get; }
        public bool IgnoreListenerPause { get; }
        
        public AudioRolloffMode RolloffMode { get; }
        
    }

    [Serializable]
    public class SoundDataAdvanced : SoundDataProvider
    {
        [SerializeField] private AudioClip clip;
        [SerializeField] private AudioMixerGroup mixerGroup;
        [SerializeField, MinMaxSlider(0, 1)] private Vector2 volumeRange = new Vector2(1, 1);
        [SerializeField, MinMaxSlider(-3, 3)] private Vector2 pitchRange = new Vector2(1, 1);
        [SerializeField] private bool loop;
        [SerializeField] private bool playOnAwake;
        [SerializeField] private bool frequentSound;
        [SerializeField, Range(0, 256)] private int priority = 128;
        public AudioClip Clip { get => clip; }
        public AudioMixerGroup MixerGroup { get => mixerGroup; }
        public float Volume { get => Random.Range(volumeRange.x, volumeRange.y); }
        public float Pitch { get => Random.Range(pitchRange.x, pitchRange.y); }
        public bool Loop { get => loop; }
        public bool PlayOnAwake { get => playOnAwake; }
        public bool FrequentSound { get => frequentSound; }
        public bool Mute { get => false; }
        public bool BypassEffects { get => false; }
        public bool BypassListenerEffects { get => false; }
        public bool BypassReverbZones { get => false; }
        public int Priority { get => priority; }
        public float PanStereo { get => 0; }
        public float SpatialBlend { get => 0; }
        public float ReverbZoneMix { get => 1; }
        public float DopplerLevel { get => 1; }
        public float Spread { get => 0; }
        public float MinDistance { get => 1; }
        public float MaxDistance { get => 500; }
        public bool IgnoreListenerVolume { get => false; }
        public bool IgnoreListenerPause { get => false; }
        public AudioRolloffMode RolloffMode { get => AudioRolloffMode.Logarithmic; }
    }

    [Serializable]
    public class SoundDataSimple : SoundDataProvider
    {
        [SerializeField] private AudioClip clip;
        [SerializeField] private AudioMixerGroup mixerGroup;
        [SerializeField, MinMaxSlider(0, 1)] private Vector2 volumeRange = new Vector2(1, 1);
        [SerializeField, MinMaxSlider(-3, 3)] private Vector2 pitchRange = new Vector2(1, 1);
        public AudioClip Clip { get => clip; }
        public AudioMixerGroup MixerGroup { get => mixerGroup; }
        public float Volume { get => Random.Range(volumeRange.x, volumeRange.y); }
        public float Pitch { get => Random.Range(pitchRange.x, pitchRange.y); }
        public bool Loop { get => false; }
        public bool PlayOnAwake { get => false; }
        public bool FrequentSound { get => false; }
        public bool Mute { get => false; }
        public bool BypassEffects { get => false; }
        public bool BypassListenerEffects { get => false; }
        public bool BypassReverbZones { get => false; }
        public int Priority { get => 128; }
        public float PanStereo { get => 0; }
        public float SpatialBlend { get => 0; }
        public float ReverbZoneMix { get => 1; }
        public float DopplerLevel { get => 1; }
        public float Spread { get => 0; }
        public float MinDistance { get => 1; }
        public float MaxDistance { get => 500; }
        public bool IgnoreListenerVolume { get => false; }
        public bool IgnoreListenerPause { get => false; }
        public AudioRolloffMode RolloffMode { get => AudioRolloffMode.Logarithmic; }
    }
}