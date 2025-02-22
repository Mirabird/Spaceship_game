using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public int currentHealth, maxHealth, damageAmount;
    public HealthBar healthBar;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if (PlayerStats.instance == null)
        {
            Debug.LogError("PlayerStats.instance is NULL in PlayerHealth!");
            return;
        }

        maxHealth = PlayerStats.instance.health;
        currentHealth = maxHealth;
        
        damageAmount = PlayerStats.instance.damage;

        if (healthBar != null) 
            healthBar.SetMaxHealth(maxHealth);
        else 
            Debug.LogError("healthBar is not assigned in PlayerHealth!");
    }

    public void DealDamage()
    {
        currentHealth -= damageAmount;
        AudioManager.instance.PlaySfx(1);
        UIController.instance.ShowDamage();
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            AudioManager.instance.StopBgm();
            GameManager.instance.ShowGameOver();
            Debug.Log("Player is dead");
        }
    }
    public void TakeDamage(int damage)
    {
        PlayerStats.instance.health -= damage;
        UpdateHealth();
        damageAmount = PlayerStats.instance.damage;  
        UIController.instance.UpgradeDamage(); 
        UIController.instance.ShowDamage();
        
        UIController.instance.damageText.text = "Damage: " + PlayerStats.instance.damage;
    }
    public void UpdateHealth()
    {
        currentHealth = PlayerStats.instance.health;
        healthBar.SetHealth(currentHealth);
        UIController.instance.UpdateUI();
    }
    public void UpgradeHealth()
    {
        if (PlayerStats.instance.TryUpgradeHealth())
        {
            UIController.instance.UpdateUI();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Killer"))
        {
            AudioManager.instance.StopBgm();
            GameManager.instance.ShowGameOver();
            Debug.Log("Player is dead");
        }
        else if (collision.gameObject.CompareTag("SciFiBuilding"))
        {
            AudioManager.instance.StopBgm();
            GameManager.instance.ShowGameOver();
            Debug.Log("Player collided with building or plane nose - Game Over");
        }
        else if (collision.gameObject.CompareTag("Wing"))
        {
            damageAmount -= 1;  
            UIController.instance.UpgradeDamage(); 

            TakeDamage(3); 
            Debug.Log("Player damaged by wing");
        }
        else if (collision.gameObject.CompareTag("SciFiBuilding"))
            {
                TakeDamage(10); 
                Debug.Log("Player collided with building - Damage applied");
            }
    }
}