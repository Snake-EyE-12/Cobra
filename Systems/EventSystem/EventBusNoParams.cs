using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

namespace Cobra.DesignPattern.Observer
{
    public class EventBusNoParams
    {
        private List<UnityAction> listeners = new();

        public void AddListener(UnityAction @event)
        {
            listeners.Add(@event);
        }

        public static EventBusNoParams operator +(EventBusNoParams bus, UnityAction e)
        {
            bus.AddListener(e);
            return bus;
        }

        public static EventBusNoParams operator -(EventBusNoParams bus, UnityAction e)
        {
            bus.RemoveListener(e);
            return bus;
        }

        public void RemoveListener(UnityAction @event)
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

        public void Invoke()
        {
            foreach (var listener in listeners)
            {
                listener.Invoke();
            }
        }
        
        public int Count => listeners.Count;
        public void Clear() => listeners.Clear();
    }

    public class EventBusNoParamsDictionary
    {
        public Dictionary<string, EventBusNoParams> events = new Dictionary<string, EventBusNoParams>();

        public void AddListener(string key, UnityAction @event)
        {
            if (events.TryGetValue(key, out EventBusNoParams bus))
            {
                bus.AddListener(@event);
            }
            else
            {
                EventBusNoParams newBusWeak = new EventBusNoParams();
                newBusWeak.AddListener(@event);
                events.TryAdd(key, newBusWeak);
            }
        }

        public void RemoveListener(string key, UnityAction @event)
        {
            if (events.TryGetValue(key, out EventBusNoParams bus))
            {
                bus.RemoveListener(@event);
            }
        }

        public void Invoke(string key)
        {
            if (events.TryGetValue(key, out EventBusNoParams bus))
            {
                bus.Invoke();
            }
        }

        public int Entries => events.Count;
        public int Count(string key) => events.TryGetValue(key, out EventBusNoParams bus) ? bus.Count : 0;
        public void Clear(string key)
        {
            if (events.TryGetValue(key, out EventBusNoParams bus))
            {
                bus.Clear();
            }
        }
        public void ClearAll() => events.Clear();
        public List<string> Keys => events.Keys.ToList();
    }
}