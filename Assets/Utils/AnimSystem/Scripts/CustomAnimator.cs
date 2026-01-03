using System.Collections.Generic;
using UnityEngine;

public class CustomAnimator : MonoBehaviour
{
    // NOTE : In optimals conditions the same script wouldn't have both responsabilities (polling input and animation management) but for example sake it's simpler
    // Also the transitions between the animation pos are kinda violent because that's just random mixamo anims and not anims made to work together

    // Animation
    public AnimDatabase animDB;
    private Animator animator;
    private string currentState;
    private float animationDelay;

    // Flags
    private bool isAttacking;

    private void Awake() {
        animator = GetComponent<Animator>();
        animDB.Initialise();
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
            ChangeAnimationState(animDB.Get(AnimID.BreathingIdle).name);
        if (Input.GetKeyDown(KeyCode.R))
            ChangeAnimationState(animDB.Get(AnimID.FastRun).name);
        if (Input.GetKeyDown(KeyCode.W))
            ChangeAnimationState(animDB.Get(AnimID.Walking).name);
        
        // === Attack ===
        if (!isAttacking && Input.GetKeyDown(KeyCode.Mouse0)) {
            isAttacking = true;
            var attackAnim = animDB.Get(AnimID.Attack);
            ChangeAnimationState(attackAnim.name);

            // Set up callback
            animationDelay = attackAnim.duration;
            Invoke("AttackComplete", animationDelay);
        }                                            
    }

    private void AttackComplete() {
        isAttacking = false;
        ChangeAnimationState("BreathingIdle");
    }

}
