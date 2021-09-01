using DG.Tweening;
using System.Collections;
using UnityEngine;
using Zenject;

public abstract class Obstacle : MonoBehaviour
{
    private ILevelManager levelManager;
    private Rigidbody playerRb;
  
    [Inject]
    public void Setup(ILevelManager levelManager,Rigidbody playerRb)
    {
        this.levelManager = levelManager;
        this.playerRb = playerRb;
        
    }
    public void KillPlayer()
    {
        Debug.Log("Level Starts Again");
        levelManager.ContinueLevelFromStart();
    }
    public void PushPlayer(Vector3 pushPos,float pushForce=0f)
    {
        //Alternative
        //var playerT = GameObject.FindGameObjectWithTag("Player").transform;
        //playerT.DOMove(pushForce * pushPos,1f);
        Debug.Log(playerRb.velocity);
        playerRb.AddForce(pushPos * pushForce, ForceMode.Impulse);
       

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
