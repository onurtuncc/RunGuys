using DG.Tweening;
using System.Collections;
using UnityEngine;
using Zenject;

public abstract class Obstacle : MonoBehaviour
{
    private ILevelManager levelManager;
    [Inject]
    public void Setup(ILevelManager levelManager)
    {
        this.levelManager = levelManager;
    }
    public void KillPlayer()
    {
        Debug.Log("Level Lost");
        levelManager.LevelLost();

    }
    public void PushPlayer(Vector3 pushPos,float pushForce=0f)
    {
        var playerT = GameObject.FindGameObjectWithTag("Player").transform;
        playerT.DOMove(pushForce * pushPos,1f);
       

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
