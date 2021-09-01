using Zenject;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface ILevelManager
{
    void LevelWin();
    void ContinueLevelFromStart();

}
public class LevelManager : ILevelManager
{

    private IAnimationManager animationManager;
    private IMovementManager movementManager;
    private MovementController playerMovement;
    private Rigidbody playerRigidbody;

    [Inject]
    private PaintBrush paintBrush;
    
    

    [Inject]
    public void Setup( IAnimationManager animationManager, IMovementManager movementManager, MovementController playerMovement,Rigidbody playerRigidbody)
    {
        
        this.animationManager = animationManager;
        this.movementManager = movementManager;
        this.playerMovement = playerMovement;
        this.playerRigidbody = playerRigidbody;
    }


    public void LevelWin()
    {
        movementManager.StopMovement();
        playerMovement.transform.position = new Vector3(0, playerMovement.transform.position.y, playerMovement.transform.position.z);
        animationManager.PlayAnimation("Win");
        paintBrush.gameObject.SetActive(true);
        playerMovement.gameObject.GetComponent<RankController>().finishedLevel=true;


    }
    
    public void ContinueLevelFromStart()
    {
        movementManager.StopMovement();
        playerRigidbody.velocity = Vector3.zero;
        playerMovement.gameObject.transform.position = Vector3.zero;
        movementManager.ContinueMovement();
    }
    

}
