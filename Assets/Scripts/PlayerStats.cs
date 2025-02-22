using UnityEngine;
public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    public int health = 100;
    public int damage = 10;
    public int UpgradePoints { get; private set; }
    public int level = 1;  

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("PlayerStats initialized");
            DontDestroyOnLoad(gameObject);      
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void ResetStats()
    {
        health = 100;
        damage = 10;
        UpgradePoints = 0;
        level = 1;
        
        PlayerMovement.instance.forwardspeed = 70f; 
        UIController.instance.UpdateUI();
    }
    public float GetSpeed()
    {
        if (PlayerMovement.instance != null)
        {
            return PlayerMovement.instance.forwardspeed;
        }
        else
        {
            Debug.LogError("PlayerMovement instance is null!");
            return 0f; 
        }
    }
    public void AddUpgradePoints(int points)
    {
        UpgradePoints += points;
        UIController.instance.UpdateUI();
    }
    public bool TryUpgradeHealth()
    {
        if (UpgradePoints > 0)
        {
            health += 10;
            UpgradePoints--;
            UIController.instance.UpdateUI();
            return true;
        }
        return false;
    }
    public bool TryUpgradeDamage()
    {
        if (UpgradePoints > 0)
        {
            damage += 5;
            UpgradePoints--;
            UIController.instance.UpdateUI();
            return true;
        }
        return false;
    }
    
    public bool TryUpgradeSpeed()
    {
        if (UpgradePoints > 0)
        {
            PlayerMovement.instance.forwardspeed += 10f;  
            Debug.Log("Speed upgraded: " + PlayerMovement.instance.forwardspeed); 
            UpgradePoints--;
            UIController.instance.UpdateUI();  
            return true; 
        }
        return false;
    }

}