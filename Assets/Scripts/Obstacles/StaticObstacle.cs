using UnityEngine;

public class StaticObstacle : Obstacle, IObstacle
{
    public void interact()
    {
        base.KillPlayer();
        
    }

}
