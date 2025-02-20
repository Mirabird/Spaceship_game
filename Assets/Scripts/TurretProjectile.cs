using UnityEngine;
public class TurretProjectile : MonoBehaviour
{
    public int damage = 10;

    // The projectile is moving towards the player
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Dealing damage to the player
            collision.gameObject.GetComponent<PlayerHealth>().DealDamage();
            Destroy(gameObject);  
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);  // Destroy the projectile when it collides with an obstacle
        }
    }
}
