using UnityEngine;

[CreateAssetMenu(fileName = "AnimData", menuName = "Animation/AnimData")]
public class AnimData : ScriptableObject {
    
    [Header("References")]
    public AnimID id;
    public AnimationClip clip;

    [Header("Clip Infos")] // TODO : Should be readonly in editor but I don't want to have to create a property drawer right now
    public string animatorStateName => clip != null ? clip.name : "";
    public float duration => clip != null ? clip.length : 0f;

    [Header("Flags")]
    public bool isCancellable;
    public bool isBlockingMovements;

    // TODO Add a flag 'isBlockingInputs' ?
}
