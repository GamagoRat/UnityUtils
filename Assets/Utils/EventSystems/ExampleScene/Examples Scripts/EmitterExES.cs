using UnityEngine;

public class EmitterExES : MonoBehaviour
{
    [Header("Events")]
    public GameEvent changeColorEvent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && changeColorEvent != null)
            changeColorEvent.Raise(this, null);
    }
}
