using UnityEngine;
public class DamagePlayer : MonoBehaviour
{
    public GameObject damageEffectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("We collided with spaceship");

            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // the direction from the player to the point of collision
            Vector3 collisionPoint = other.ClosestPoint(transform.position);
            Vector3 collisionDirection = (collisionPoint - other.transform.position).normalized;

            // Checking the angle of collision relative to the front of the ship
            float dotProduct = Vector3.Dot(other.transform.forward, collisionDirection);

            if (dotProduct > 0.7f) // 0.7 ≈ 45° 
            {
                Debug.Log("Head-on collision! Player is dead.");
                playerHealth.KillPlayer(); // Death
            }
            else
            {
                Debug.Log("Side collision detected");
                playerHealth.DealDamage(); // Damage
            }

            Instantiate(damageEffectPrefab, collisionPoint, Quaternion.identity);
        }
    }
}