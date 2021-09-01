using UnityEngine;
using Zenject;

public interface IAnimationManager
{
    void PlayAnimation(string animation);
}
public class AnimationManager : IAnimationManager
{
    
    [Inject]
    private Animator playerAnimator;
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
