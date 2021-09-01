using UnityEngine;
using Zenject;
public class CharacterController : MonoBehaviour
{
    
    private ILevelManager levelManager;
    [Inject]
    public void Setup(ILevelManager levelManager)
    {
        this.levelManager = levelManager;
    }
    private void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish") levelManager.LevelWin();
        if (collision.gameObject.tag != "Obstacle") return;
        Debug.Log("Hit Obstacle");
        
        var _obstacle = collision.gameObject.GetComponent<IObstacle>();
        if(_obstacle == null)
        {
            _obstacle = collision.transform.root.GetComponent<IObstacle>();
        }
        if (_obstacle != null) _obstacle.interact();
       


    }
}
