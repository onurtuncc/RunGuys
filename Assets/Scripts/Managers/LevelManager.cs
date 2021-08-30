using Zenject;
public interface ILevelManager
{
    void LevelWin();
    void LevelLost();
}
public class LevelManager : ILevelManager
{

    private IAnimationManager animationManager;
    private IMovementManager movementManager;



    [Inject]
    public void Setup( IAnimationManager animationManager, IMovementManager movementManager)
    {
        
        this.animationManager = animationManager;
        this.movementManager = movementManager;
    }
    
    
    public void LevelWin()
    {
        movementManager.StopMovement();
        animationManager.PlayAnimation("Win");
    }

    public void LevelLost()
    {
        movementManager.StopMovement();
        animationManager.PlayAnimation("Death");
    }
}
