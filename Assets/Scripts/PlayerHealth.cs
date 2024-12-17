 using UnityEngine;
 using UnityEngine.SceneManagement;
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
        UIController.instance.ShowDamage();
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    //die, restart level or effect
            Debug.Log("Player is dead");  
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Killer")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   //die, level restart
            Debug.Log("Player is died");
        }
    }
}
