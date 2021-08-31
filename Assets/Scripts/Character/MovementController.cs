using UnityEngine;
using Zenject;

public class MovementController : MonoBehaviour
{
    private SwerveInputSystem _swerveInputSystem;
    private IMovementManager movementManager;
    [Inject]
    public void Setup(IMovementManager movementManager)
    {
        this.movementManager = movementManager;
    }

    private void Awake()
    {
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
        
    }
    private void Update()
    {
        float swerveAmount = Time.deltaTime * movementManager.GetSwerveSpeed() * _swerveInputSystem.MoveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -movementManager.GetMaxSwerveAmount(), movementManager.GetMaxSwerveAmount());
        transform.Translate(swerveAmount, 0, movementManager.GetForwardSpeed()*Time.deltaTime);

    }

    
}
