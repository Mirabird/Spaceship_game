using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    
    public float forwardspeed =70f;
    public float speed = 50f;
    private Rigidbody rb;
    public float rotationSpeed = 100f; 
    public float maxTiltAngle = 30f;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 forwardMovement = transform.forward * forwardspeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMovement);

        float horizontalInput = Input.GetAxis("Horizontal");

        rb.velocity =  new Vector3(horizontalInput * speed, 0,0);

        float tiltAngle = -horizontalInput * maxTiltAngle;
        
        Quaternion wingTilt = Quaternion.Euler(0, 0, tiltAngle);

        transform.localRotation = Quaternion.Slerp(transform.localRotation, wingTilt, Time.fixedDeltaTime * 5f);
    }
}