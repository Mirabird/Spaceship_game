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
        
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10); 
            }
            Instantiate(damageEffectPrefab, transform.position, Quaternion.identity);
        }
    }

}