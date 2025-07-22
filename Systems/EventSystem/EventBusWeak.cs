using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cobra.DesignPattern.Observer
{
    public class EventBusWeak
    {
        private class EventListener
        {
            public Delegate d;
            public List<Type> typeParams = new List<Type>();
        }
        private List<EventListener> listeners = new();

        public void AddListener(Delegate @event)
        {
            listeners.Add(new EventListener() { d = @event, typeParams = ToTypes(@event) });
        }

        public static EventBusWeak operator +(EventBusWeak busWeak, Delegate e)
        {
            busWeak.AddListener(e);
            return busWeak;
        }

        public static EventBusWeak operator -(EventBusWeak busWeak, Delegate e)
        {
            busWeak.RemoveListener(e);
            return busWeak;
        }

        public void RemoveListener(Delegate @event)
        {
            RemoveFirstDelegate(@event);
        }

        private void RemoveFirstDelegate(Delegate d)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                if (listeners[i].d.Equals(d))
                {
                    listeners.RemoveAt(i);
                    return;
                }
            }
        }

        public int Count => listeners.Count;

        private List<Type> ToTypes(Delegate d)
        {
            List<Type> typeParams = new List<Type>();
            MethodInfo methodInfo = d.Method;
            ParameterInfo[] parameters = methodInfo.GetParameters();
            foreach (var parameter in parameters)
            {
                typeParams.Add(parameter.GetType());
            }

            return typeParams;
        }

        public void Invoke(params object[] parameters)
        {
            List<Type> typeParams = new List<Type>();
            foreach (var parameter in parameters)
            {
                typeParams.Add(parameter.GetType());
            }

            foreach (var listener in listeners)
            {
                if (Matches(typeParams, listener.typeParams))
                {
                    listener.d?.DynamicInvoke(parameters);
                }
            }
        }

        private bool Matches(List<Type> option1, List<Type> option2)
        {
            if (option1.Count != option2.Count) return false;
            for (int i = 0; i < option1.Count; i++)
            {
                if (option1[i].GetType() != option2[i].GetType()) return false;
            }

            return true;
        }

        public void Clear() => listeners.Clear();
    }

    public class EventBusWeakDictionary
    {
        public Dictionary<string, EventBusWeak> events = new Dictionary<string, EventBusWeak>();

        public void AddListener(string key, Delegate @event)
        {
            if (events.TryGetValue(key, out EventBusWeak bus))
            {
                bus.AddListener(@event);
            }
            else
            {
                EventBusWeak newBusWeak = new EventBusWeak();
                newBusWeak.AddListener(@event);
                events.TryAdd(key, newBusWeak);
            }
        }

        public void RemoveListener(string key, Delegate @event)
        {
            if (events.TryGetValue(key, out EventBusWeak bus))
            {
                bus.RemoveListener(@event);
            }
        }

        public void Invoke(string key, params object[] parameters)
        {
            if (events.TryGetValue(key, out EventBusWeak bus))
            {
                bus.Invoke(parameters);
            }
        }

        public int Entries => events.Count;
        public int Count(string key) => events.TryGetValue(key, out EventBusWeak bus) ? bus.Count : 0;
        public void Clear(string key)
        {
            if (events.TryGetValue(key, out EventBusWeak bus))
            {
                bus.Clear();
            }
        }

        public void ClearAll() => events.Clear();
        public List<string> Keys => events.Keys.ToList();
    }
}