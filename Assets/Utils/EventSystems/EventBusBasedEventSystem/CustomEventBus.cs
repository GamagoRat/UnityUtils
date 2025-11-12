using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


// NOTE Added "Custom" in order not to shadow Unity built-in Event Bus in VisualScripting
public class CustomEventBus : MonoBehaviour
{

    public static CustomEventBus Instance;
    private static Dictionary<EventsEnum, Action> assignedEvents = new();

    private void Awake()
    {
        // Ensure Singleton
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public static void Register(EventsEnum ev, Action action)
    {
        // If the event doesn't yet have a key in the dict add one, then add the action
        // Else only add the action to the existing key
        if (!assignedEvents.ContainsKey(ev)) 
            assignedEvents[ev] = action;
        else 
            assignedEvents[ev] += action;
    }

    public static void Unregister(EventsEnum ev, Action action)
    {
        if (assignedEvents.ContainsKey(ev)) 
            assignedEvents[ev] -= action;
    }

    public static void RaiseEvent(EventsEnum ev)
    {
        if(assignedEvents.TryGetValue(ev, out Action response))
            response?.Invoke();
    }

    /*private void Dump()
    {
        EventHook hook = new EventHook("Event");
        EventBus.Trigger(hook);
        Action<> floatAction = (f) => f * 2;
        EventBus.Unregister(hook, floatAction);
    }*/

}
