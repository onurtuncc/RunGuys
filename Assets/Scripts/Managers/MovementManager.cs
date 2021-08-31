public interface IMovementManager
{
    void StopMovement();
    void ContinueMovement();
    float GetSwerveSpeed();
    float GetForwardSpeed();
    float GetMaxSwerveAmount();

}
public class MovementManager : IMovementManager
{

    private float forwardSpeed=5;
    private float swerveSpeed=0.5f;
    private float maxSwerveAmount=1;
    private float tempForwardSpeed=0;
    private float tempSwerveSpeed=0;
    
    
    public void StopMovement()
    {
        tempForwardSpeed = forwardSpeed;
        tempSwerveSpeed = swerveSpeed;
        forwardSpeed = 0f;
        swerveSpeed = 0f;

    }

    public void ContinueMovement()
    {
        forwardSpeed = tempForwardSpeed;
        swerveSpeed = tempSwerveSpeed;
    }
    public float GetSwerveSpeed()
    {
        return swerveSpeed;
    }
    public float GetForwardSpeed()
    {
        return forwardSpeed;
    }
    public float GetMaxSwerveAmount()
    {
        return maxSwerveAmount;
    }

    
}
