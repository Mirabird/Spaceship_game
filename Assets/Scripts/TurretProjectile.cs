using UnityEngine;
public class TurretProjectile : MonoBehaviour
{
    public int damage = 10;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().DealDamage();
            Destroy(gameObject);  
        }
    }
}
