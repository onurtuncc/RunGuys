﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorObstacle : Obstacle, IObstacle
{
    [SerializeField]private float rotateSpeed = 200f;
    //To push player in the right z direction
    private float forward=1f;
    //Push z direction amount
    private float pushPlayerForce = 8f;
    
    private void Update()
    {
        transform.Rotate(new Vector3(0, Time.deltaTime * rotateSpeed, 0));
      
    }
    public void interact()
    {
        if (transform.rotation.eulerAngles.y <= 180)
        {
            forward = -forward;
        }
        var forceVector = new Vector3(Mathf.Tan((90-transform.rotation.eulerAngles.y)*Mathf.Deg2Rad), 0, transform.position.z+pushPlayerForce*forward);
        Debug.Log(forceVector);
        base.PushPlayer(forceVector, 1);
        forward = 1f;

    }
    
}
