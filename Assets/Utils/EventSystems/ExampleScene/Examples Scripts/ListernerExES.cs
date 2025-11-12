using UnityEngine;

public class ListenerExES : MonoBehaviour
{
    private Material material;

    public void Start() { material = GetComponent<Renderer>().material; }
    public void ChangeColor() { material.color = Random.ColorHSV(); }
}
