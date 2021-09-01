using UnityEngine;
using UnityEngine.AI;
public class OpponentAI : MonoBehaviour
{
    
    [SerializeField] private Transform endingTransform;
    private NavMeshAgent agent;
    private Vector3 startPoint;
    private Animator opponentAnimator;
    private bool hasReachedEnd = false;
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
        if (hasReachedEnd) return;
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
            agent.isStopped = true;
            hasReachedEnd = true;
            agent.GetComponent<Rigidbody>().velocity = Vector3.zero;
            agent.transform.rotation = Quaternion.Euler(0, 180, 0);
            opponentAnimator.SetTrigger("winTrigger");
            agent.transform.position = startPoint + Vector3.forward * (endingTransform.position.z+8f);
            
            
        }
    }
}
