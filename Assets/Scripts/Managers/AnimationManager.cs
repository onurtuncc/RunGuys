using UnityEngine;

public interface IAnimationManager
{
    void PlayAnimation(string animation);
}
public class AnimationManager : IAnimationManager
{
    private Animator playerAnimator=GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();
    public void PlayAnimation(string animation)
    {
        if (playerAnimator == null) return;
        if (animation == "Win")
        {
            playerAnimator.SetTrigger("winTrigger");

        }
        else if (animation == "Death") playerAnimator.SetTrigger("deadTrigger");
    }
}
