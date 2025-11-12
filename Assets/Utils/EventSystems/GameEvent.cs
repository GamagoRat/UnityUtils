using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Event System/GameEvent")]
public class GameEvent : ScriptableObject
{
    // TODO Is this approach better ?
    // public event Action Event;
    //public void Raise() => Event?.Invoke();

    // NOTE This event system is not trade safe

    [System.NonSerialized] // Avoid persistent ref between editor and runtime
    private readonly List<EventListener> listeners = new List<EventListener>(); // TODO use a hashSet instead of list for better performance ?

    public void RegisterListener(EventListener listener) 
    {

        if (listener == null) return;
        if (!listeners.Contains(listener))
            listeners.Add(listener);
    }

    public void UnregisterListener(EventListener listener){ listeners.Remove(listener); }

    public void Raise(Component sender, object data)
    {
        for (int i = listeners.Count -1;  i >= 0; i--) {
            var listener = listeners[i];
            listener.OnEventRaised(sender, data);
        }
    }

}

// TODO Class GameEvent Template ?
/*public class GameEvent<T> : ScriptableObject
{
    public event Action<T> Event;

    public void Raise(T t) => Event?.Invoke(t);
}*/


