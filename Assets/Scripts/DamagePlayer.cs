using UnityEngine;
public class DamagePlayer : MonoBehaviour
{
    public GameObject damageEffectPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("We collided with space ship");
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.DealDamage();

            Instantiate(damageEffectPrefab, other.transform.position, Quaternion.identity);
        }
    }
}
