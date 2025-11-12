using UnityEngine;

public class EventBusRCEx : MonoBehaviour
{

    private Material material;

    private void Start()
    { 
        // Register the Event
        CustomEventBus.Register(EventsEnum.RandomColorEvent, ChangeRandomColor);
        // Get the material
        material = GetComponent<Renderer>().material;
    }

    private void ChangeRandomColor() { material.color = Random.ColorHSV(); }

}
