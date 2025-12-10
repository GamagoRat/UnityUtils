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
    }

}
