using UnityEngine;

[CreateAssetMenu(fileName = "AnimData", menuName = "Animation/AnimData")]
public class AnimData : ScriptableObject {
    
    [Header("References")]
    public AnimID id;
    public AnimationClip clip;

    // Clip Infos
    public string animatorStateName => clip != null ? clip.name : " "; // TODO/NOTE Could be improved on this point as the anim name must be 
    public float duration => clip != null ? clip.length : 0f;          // the exact same that the state in the animator and discrepencies can appear if anims are renamed

    [Header("Flags")]
    public bool isCancellable;
    public bool isBlockingMovements;

    // TODO Add a flag 'isBlockingInputs' ?
}
