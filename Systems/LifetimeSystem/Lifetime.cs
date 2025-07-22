using System;
using NaughtyAttributes;
using UnityEngine;
using Random = UnityEngine.Random;

public class Lifetime : MonoBehaviour
{
    [SerializeField] private LifetimeType type;
    [SerializeField, ShowIf("type", LifetimeType.Constant)] private float lifetime;
    [SerializeField, MinMaxSlider(0, 100), ShowIf("type", LifetimeType.RandomRange)] private Vector2 rangedLifetime;

    protected void StartLifetimeTimer()
    {
        Invoke(nameof(OnEnd), GetLifetime());
    }
    private void OnEnable()
    {
        StartLifetimeTimer();
    }

    private void OnEnd()
    {
        OnLifetimeEnd();
    }

    private float GetLifetime()
    {
        if (type == LifetimeType.Constant) return lifetime;
        return Random.Range(rangedLifetime.x, rangedLifetime.y);
    }

    protected virtual void OnLifetimeEnd()
    {
        Destroy(this.gameObject);
    }
}

public enum LifetimeType
{
    Constant,
    RandomRange
}