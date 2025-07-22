using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

namespace Cobra.DesignPattern.Observer
{
    public class EventBus<T>
    {
        private List<UnityAction<T>> listeners = new();

        public void AddListener(UnityAction<T> @event)
        {
            listeners.Add(@event);
        }

        public static EventBus<T> operator +(EventBus<T> bus, UnityAction<T> e)
        {
            bus.AddListener(e);
            return bus;
        }

        public static EventBus<T> operator -(EventBus<T> bus, UnityAction<T> e)
        {
            bus.RemoveListener(e);
            return bus;
        }

        public void RemoveListener(UnityAction<T> @event)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                if (listeners[i].Equals(@event))
                {
                    listeners.RemoveAt(i);
                    return;
                }
            }
        }

        public void Invoke(T value)
        {
            foreach (var listener in listeners)
            {
                listener.Invoke(value);
            }
        }
        
        public int Count => listeners.Count;
        public void Clear() => listeners.Clear();
    }

    public class EventBusDictionary<T>
    {
        public Dictionary<string, EventBus<T>> events = new Dictionary<string, EventBus<T>>();

        public void AddListener(string key, UnityAction<T> @event)
        {
            if (events.TryGetValue(key, out EventBus<T> bus))
            {
                bus.AddListener(@event);
            }
            else
            {
                EventBus<T> newBusWeak = new EventBus<T>();
                newBusWeak.AddListener(@event);
                events.TryAdd(key, newBusWeak);
            }
        }

        public void RemoveListener(string key, UnityAction<T> @event)
        {
            if (events.TryGetValue(key, out EventBus<T> bus))
            {
                bus.RemoveListener(@event);
            }
        }

        public void Invoke(string key, T value)
        {
            if (events.TryGetValue(key, out EventBus<T> bus))
            {
                bus.Invoke(value);
            }
        }

        public int Entries => events.Count;
        public int Count(string key) => events.TryGetValue(key, out EventBus<T> bus) ? bus.Count : 0;
        public void Clear(string key)
        {
            if (events.TryGetValue(key, out EventBus<T> bus))
            {
                bus.Clear();
            }
        }
        public void ClearAll() => events.Clear();
        public List<string> Keys => events.Keys.ToList();
    }
}