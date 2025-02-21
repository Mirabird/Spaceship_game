using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    public int health = 100;
    public int damage = 10;
    public float speed = 5f;
    public int UpgradePoints { get; private set; }
    public int level = 1;  

    private void Awake()
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
            speed += 1f;
            UpgradePoints--;
            UIController.instance.UpdateUI();
            return true;
        }
        return false;
    }
}