using System;
using UnityEngine;

namespace Cobra.Utilities
{
    [Serializable]
    public class Curve
    {
        [SerializeField] private AnimationCurve curve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        [SerializeField] private float yMax;
        [SerializeField] private float yMin;
        [SerializeField] private float xMax;
        [SerializeField] private float xMin;
        public bool IsInRange(float x) => x >= xMin && x <= xMax;
    
        public float Evaluate(float x) => curve.Evaluate((Mathf.Clamp(x, xMin, xMax) - xMin) / (xMax - xMin)) * (yMax - yMin) + yMin;
    
        public bool TryEvaluate(float x, out float result)
        {
            result = 0;
            if (!IsInRange(x)) return false;
            result = Evaluate(x);
            return true;
        }
    }
}
