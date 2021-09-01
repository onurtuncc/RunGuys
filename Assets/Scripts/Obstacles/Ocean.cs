using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocean : Obstacle, IObstacle
{
    public void interact()
    {
        base.KillPlayer();
    }
}
