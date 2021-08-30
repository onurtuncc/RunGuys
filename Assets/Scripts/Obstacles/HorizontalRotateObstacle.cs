using UnityEngine;
public class HorizontalRotateObstacle : Obstacle, IObstacle
{
    private float moveDuration = 3f;

    private void Start()
    {
        base.MoveObstacle(moveDuration,transform);
    }
    private void Update()
    {
        transform.Rotate(new Vector3(0, Time.deltaTime * 360 / moveDuration, 0));
    }
    public void interact()
    {
        base.KillPlayer();
       
    }
    
}
