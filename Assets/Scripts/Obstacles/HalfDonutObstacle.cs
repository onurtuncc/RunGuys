using UnityEngine;

public class HalfDonutObstacle : Obstacle, IObstacle
{
    private Transform movingStick;
    private float moveDuration = 0.5f;
    private bool toLeft;
    private float pushForce = 4f;
    private void Start()
    {
        movingStick = transform.GetChild(0);
        base.MoveObstacle(moveDuration,movingStick);
        if (transform.root.rotation.y == 0) toLeft = true;
        else toLeft = false;
    }

    public void interact()
    {
        if(toLeft) base.PushPlayer(new Vector3(-1, 0, transform.position.z / pushForce), pushForce);
        else base.PushPlayer(new Vector3(1,0,transform.position.z/pushForce), pushForce);

    }


    
}
