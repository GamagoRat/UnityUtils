using UnityEngine;

public class ListenerEx2ES : MonoBehaviour
{
    private Material material;

    public void Start() { material = GetComponent<Renderer>().material; }
    public void ChangeColor(Component sender, object data) 
    { 
        if (data is Color color) // TODO Check if that's the correct way to do that
            material.color = color; 
    }

}
