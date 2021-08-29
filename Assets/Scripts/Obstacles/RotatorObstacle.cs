using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorObstacle : Obstacle, IObstacle
{
    private float rotateSpeed = 50f;
    private void Update()
    {
        transform.Rotate(new Vector3(0, Time.deltaTime * rotateSpeed, 0));
    }
    public void interact()
    {
        
    }
}
