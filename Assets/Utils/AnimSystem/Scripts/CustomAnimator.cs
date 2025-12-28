using System.Collections.Generic;
using UnityEngine;

public class CustomAnimator : MonoBehaviour
{
    // NOTE : In optimals conditions the same script wouldn't have both responsabilities (polling input and animation management) but for example sake it's simpler
    // Also the transitions between the animation pos are kinda violent because that's just random mixamo anims and not anims made to work together

    // Animation
    private Animator animator;
    private string currentState;
    private float animationDelay;
    private Dictionary<string, float> clipLengths;

    // Flags
    private bool isAttacking;

    private void Awake()
    {
        // Initialisation
        clipLengths = new Dictionary<string, float>();
        animator = GetComponent<Animator>();

        // Get the clips length
        foreach (var clip in animator.runtimeAnimatorController.animationClips)
            if (!clipLengths.ContainsKey(clip.name))
                clipLengths.Add(clip.name, clip.length);
    }

    public void ChangeAnimationState(string newState) {

        // Early exit
        if (currentState == newState)
            return;

        // Play the animation
        currentState = newState;
        animator.Play(newState);
    }

    public void Update()
    {
        // === Looping Anims === 
        if (Input.GetKeyDown(KeyCode.B))
            ChangeAnimationState("BreathingIdle");
        if (Input.GetKeyDown(KeyCode.R))
            ChangeAnimationState("FastRun");
        if (Input.GetKeyDown(KeyCode.W))
            ChangeAnimationState("Walking");
        
        // === Attack ===
        if (!isAttacking && Input.GetKeyDown(KeyCode.Mouse0)) {
            isAttacking = true;
            ChangeAnimationState("Attack");

            // Set up callback
            animationDelay = clipLengths["Attack"];  // TODO : That's where I wonder if, in a bigger system,
            Invoke("AttackComplete", animationDelay);// it wouldn't be more worth it t oset up differently named delay and initialise them at awake
        }                                            // instead of looking up, or better have some sort of data struct like scriptable object to manage that
    }

    private void AttackComplete() {
        isAttacking = false;
        ChangeAnimationState("BreathingIdle");
    }

}
