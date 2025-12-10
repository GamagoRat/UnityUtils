using UnityEngine;

public class CustomAnimator : MonoBehaviour
{

    private Animator animator;
    private string currentState;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeAnimationState(string newState)
    {

        // Early exit
        if (currentState == newState)
            return;
        // Play the animation
        animator.Play(newState);
    }

}
