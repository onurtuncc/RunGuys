using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
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
