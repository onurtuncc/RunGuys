using DG.Tweening;
using System.Collections;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    public void KillPlayer()
    {
        Debug.Log("Player is dead");
        //Play death animation
        //Restart the scene vs..
    }
    public void PushPlayer(float pushForce=0f,bool toLeft=true)
    {
        var playerT = GameObject.FindGameObjectWithTag("Player").transform;
        if (toLeft) pushForce = -pushForce;
        playerT.DOMoveX(pushForce, 1f);

    }
    public void MoveObstacle(float duration,Transform moveObject)
    {
        StartCoroutine(Move(duration,moveObject));
    }
    IEnumerator Move(float duration,Transform moveObject)
    {
        while (true)
        {
            moveObject.DOLocalMoveX(-moveObject.localPosition.x, duration);
            yield return new WaitForSeconds(duration);
        }
    }
}
