using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float forwardspeed =10f;
    public float speed = 10f;
    private Rigidbody rb;
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
    }
}
