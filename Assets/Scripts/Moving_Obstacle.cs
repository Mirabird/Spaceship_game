using UnityEngine;
public class Moving_Obstacle : MonoBehaviour
{
    public Transform pointA, pointB;
    public int speed;
    private Vector3 _currentTarget;
    void Update()
    {
        if (transform.position == pointA.position)
        {
            _currentTarget = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
    }
}
