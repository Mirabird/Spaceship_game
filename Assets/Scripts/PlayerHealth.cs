using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public int currentHealth, maxHealth, damageAmount;
    public HealthBar healthBar;
    public GameObject gameOverscreen;

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
        maxHealth = PlayerStats.instance.health;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void KillPlayer()
    {
        currentHealth = 0;
        healthBar.SetHealth(currentHealth);
        AudioManager.instance.StopBgm();
        GameManager.instance.ShowGameOver();
        Debug.Log("Player is dead");
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
        UIController.instance.ShowDamage();
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
    }
}