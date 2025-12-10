using UnityEngine;

public class CustomAnimator : MonoBehaviour
{
    // NOTE : In optimals conditions the same script wouldn't have both responsabilities (polling input and animation management) but for example sake it's simpler
    // Also the transitions between the animation pos are kinda violent because that's just random mixamo anims and not anims made to work together

    // Animation
    private Animator animator;
    private string currentState;
    private float animationDelay;

    // Flags
    private bool isAttacking;

    private void Start()
    {
        animator = GetComponent<Animator>();
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
        if (Input.GetKeyDown(KeyCode.B))
            ChangeAnimationState("BreathingIdle");

        if (Input.GetKeyDown(KeyCode.R))
            ChangeAnimationState("FastRun");

        if (Input.GetKeyDown(KeyCode.W))
            ChangeAnimationState("Walking");
        
        if (!isAttacking && Input.GetKeyDown(KeyCode.Mouse0))
        {

            isAttacking = true;
            ChangeAnimationState("Attack");

            // Set up callback
            animationDelay = animator.GetCurrentAnimatorStateInfo(0).length; // FIXME Doesn't work anymore as the animation change in the next frame
            Invoke("AttackComplete", animationDelay);
        }
    }

    // TODO NEED To change that to get the anim lenght instead of just debug
    private void GetClipLength()
    {
        foreach (var clip in animator.runtimeAnimatorController.animationClips)
        {
            if (clip.name == "Attack")
                Debug.Log(clip.length);
        }
    }

    private void AttackComplete() {
        isAttacking = false;
        ChangeAnimationState("BreathingIdle");
    }

}
