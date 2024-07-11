using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is an event bus. This is used to allow different components to interact with each other 
/// without needing to be aware of each other through the use of Publisher/Subscriber messaging.
/// </summary>
/// <typeparam name="T"></typeparam>
public static class EventBus<T> where T : IEvent
{
    static readonly HashSet<IEventBinding<T>> bindings = new HashSet<IEventBinding<T>>();

    public static void Register(EventBinding<T> binding) => bindings.Add(binding);
    public static void Deregister(EventBinding<T> binding) => bindings.Remove(binding);

    public static void Raise(T @event)
    {
        foreach (var binding in bindings)
        {
            binding.OnEvent.Invoke(@event);
            binding.OnEventNoArgs.Invoke();
        }
    }

    static void Clear()
    {
        Debug.Log($"Clearing {typeof(T).Name} bindings");
        bindings.Clear();
    }
}