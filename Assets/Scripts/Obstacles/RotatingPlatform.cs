using UnityEngine;
public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private bool turnLeft = true;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Opponent")
        {
            Debug.Log("On it");
            //Move player alongside the platform
            
            collision.rigidbody.AddForce(Vector3.left * rotateSpeed,ForceMode.Acceleration);

        }
        
        
    }
    


    // Start is called before the first frame update
    void Start()
    {
        if (!turnLeft) rotateSpeed = -rotateSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotateSpeed));

    }
    
}
