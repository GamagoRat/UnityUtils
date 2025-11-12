using UnityEngine;

public class EmitterEx2ES : MonoBehaviour
{
    [Header("Events")]
    public GameEvent changeColorEvent;

    private void Update()
    {
        if (changeColorEvent != null)
        {
            if (Input.GetKeyDown(KeyCode.R))
                changeColorEvent.Raise(this, Color.red);
            if (Input.GetKeyDown(KeyCode.G))
                changeColorEvent.Raise(this, Color.green);
            if (Input.GetKeyDown(KeyCode.B))
                changeColorEvent.Raise(this, Color.blue);
        }
    }
}
