using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float forwardspeed =10f;
    public float speed = 10f;
    private Rigidbody rb;
    
    public float rotationSpeed = 100f; // rotation
    public float maxTiltAngle = 30f;
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
