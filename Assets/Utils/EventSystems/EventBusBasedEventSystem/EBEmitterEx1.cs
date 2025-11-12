using UnityEngine;

public class EBEmitterEx1 : MonoBehaviour
{
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            CustomEventBus.RaiseEvent(EventsEnum.RandomColorEvent);
    }
}
