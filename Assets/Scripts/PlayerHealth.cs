using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    public float currentHealth, maxHealth, damageAmount;
    void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void DealDamage()
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead");  //die, restart or effect
        }
    }
}
