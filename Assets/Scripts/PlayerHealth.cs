 using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    public int currentHealth, maxHealth, damageAmount;
    public HealthBar healthBar;
    public GameObject gameOverscreen;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
    }
    public void DealDamage()
    {
        currentHealth -= damageAmount;
        AudioManager.instance.PlaySfx(1);
        UIController.instance.ShowDamage();
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            GameManager.instance.ShowGameOver();
            Debug.Log("Player is dead");  
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Killer")
        {
            GameManager.instance.ShowGameOver();
            Debug.Log("Player is died");
        }
    }
}
