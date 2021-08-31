using UnityEngine;
using UnityEngine.AI;
public class OpponentAI : MonoBehaviour
{
    
    [SerializeField] private Transform endingTransform;
    private NavMeshAgent agent;
    private Vector3 startPoint;
    private Animator opponentAnimator;
    // Start is called before the first frame update
    void Awake()
    {
        opponentAnimator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = endingTransform.position;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle" && collision.gameObject.GetComponent<RotatingPlatform>()==null)
        {
            transform.position = startPoint;
        }
        if (collision.gameObject.tag == "Finish")
        {
            opponentAnimator.SetTrigger("winTrigger");
        }
    }
}
