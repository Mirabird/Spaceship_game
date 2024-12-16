using System;
using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    public int currentHealth, maxHealth, damageAmount;
    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
    }
    public void DealDamage()
    {
        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead");  //die, restart or effect
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Killer")
        {
            //die, level restart
            Debug.Log("Player is died");
        }
    }
}
