using UnityEngine;
using Zenject;

public class CameraControl : MonoBehaviour
{
    private Transform target;
    private Vector3 offset;
    private Vector3 newPos;
    [SerializeField]private float lerpSpeed=3f;
  
    void Start()
    {
        //getting players transform
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        offset = transform.position;
    }

  
    void LateUpdate()
    {
        //Following player along
        if (target != null)
        {
            newPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, newPos, lerpSpeed * Time.deltaTime);
        }
        
        
    }
}
