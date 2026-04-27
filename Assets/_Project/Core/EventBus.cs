using System;
using System.Collections.Generic;

public static class EventBus
{
    private static Dictionary<Type, Action<object>> _events = new();

    public static void Subscribe<T>(Action<T> listener)
    {
        if (_events.ContainsKey(typeof(T)))
            _events[typeof(T)] += (e) => listener((T)e);
        else
            _events[typeof(T)] = (e) => listener((T)e);
    }

    public static void Publish<T>(T eventData)
    {
        if (_events.TryGetValue(typeof(T), out var action))
            action?.Invoke(eventData);
    }
}