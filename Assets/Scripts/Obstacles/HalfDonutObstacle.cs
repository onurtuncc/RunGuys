using UnityEngine;

public class HalfDonutObstacle : Obstacle, IObstacle
{
    private Transform movingStick;
    private float moveDuration = 1f;
    private bool toLeft = true;
    private float pushForce = 4f;
    private void Start()
    {
        movingStick = transform.parent;
        base.MoveObstacle(moveDuration,movingStick);
    }

    public void interact()
    {
        base.PushPlayer(pushForce, toLeft);
    }


    
}
