using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private bool turnLeft = true;
    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag != "Player") return;
    
        collision.transform.position += Vector3.left*rotateSpeed*Time.deltaTime*0.2f;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!turnLeft) rotateSpeed = -rotateSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotateSpeed));
    }
}
