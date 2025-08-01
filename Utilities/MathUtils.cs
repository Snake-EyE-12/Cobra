using UnityEngine;

namespace Cobra.Utilities
{
    public static class MathUtils
    {
        public static bool Chance(float value)
        {
            return UnityEngine.Random.Range(0f, 100f) < value;
        }

        public static bool CompareLayerMask(LayerMask layerMask, int layer)
        {
            return (layerMask & (1 << layer)) != 0;
        }
        
        private const float MinLinearAmplitude = 1e-8f;

        public static float LinearToDecibels(float linear)
        {
            if (float.IsNaN(linear) || float.IsInfinity(linear) || linear <= 0f)
                return -160f;

            float clamped = Mathf.Max(linear, MinLinearAmplitude);
            return 20f * Mathf.Log10(clamped);
        }

        public static float DecibelsToLinear(float dB)
        {
            if (float.IsNaN(dB) || float.IsInfinity(dB))
                return 0f;

            return Mathf.Pow(10f, dB / 20f);
        }
    }
}
