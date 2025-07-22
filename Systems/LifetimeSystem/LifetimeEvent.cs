using UnityEngine;
using UnityEngine.Events;

public class LifetimeEvent : Lifetime
{
    [SerializeField] private UnityEvent onEndOfLife;
    protected override void OnLifetimeEnd()
    {
        onEndOfLife?.Invoke();
    }
}