using Zenject;
using UnityEngine;
public interface ILevelManager
{
    void LevelWin();
    void LevelLost();
    void ContinueLevelFromStart();
}
public class LevelManager : ILevelManager
{

    private IAnimationManager animationManager;
    private IMovementManager movementManager;
    private MovementController playerMovement;
    

    [Inject]
    private PaintBrush paintBrush;

    [Inject]
    public void Setup( IAnimationManager animationManager, IMovementManager movementManager, MovementController playerMovement)
    {
        
        this.animationManager = animationManager;
        this.movementManager = movementManager;
        this.playerMovement = playerMovement;
    }


    public void LevelWin()
    {
        movementManager.StopMovement();
        playerMovement.transform.position = new Vector3(0, playerMovement.transform.position.y, playerMovement.transform.position.z);
        animationManager.PlayAnimation("Win");
        paintBrush.gameObject.SetActive(true);

        

    }
    public void LevelLost()
    {
        movementManager.StopMovement();
        animationManager.PlayAnimation("Death");

    }
    public void ContinueLevelFromStart()
    {
        movementManager.StopMovement();
        playerMovement.gameObject.transform.position = Vector3.zero;
        movementManager.ContinueMovement();
    }
    
}
