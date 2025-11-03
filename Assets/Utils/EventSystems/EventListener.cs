using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class CustomGameEvent : UnityEvent<Component, object> { }

public class EventListener : MonoBehaviour
{

    [Header("Event")]
    public GameEvent gameEvent;  // Event to listen to
    public CustomGameEvent response;  // Methods to raise when the event is raiser

    // Register to the event
    private void OnEnable()
    {
        //gameEvent.Event += OnEventRaised;
        if (gameEvent != null)
            gameEvent.RegisterListener(this);
    }

    // Unregister to the event
    private void OnDisable()
    {
        //gameEvent.Event += OnEventRaised;
        if (gameEvent != null)
            gameEvent.UnregisterListener(this);

    }

    // Safely invoke the linked response event
    public void OnEventRaised(Component sender, object data){ response?.Invoke(sender, data); }

}
