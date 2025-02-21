using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public Image damageEffect;
    public float damageAlpha = 0.25f;
    public float damageFadeSpeed = 0.4f;
    public static UIController instance;

    // UI for Statistics
    public Text healthText;
    public Text levelText;
    public Text upgradePointsText;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (damageEffect.color.a != 0)
        {
            damageEffect.color = new Color(damageEffect.color.r, damageEffect.color.g, damageEffect.color.b,
                Mathf.MoveTowards(damageEffect.color.a, 0f, damageFadeSpeed * Time.deltaTime));
        }
    }

    public void ShowDamage()
    {
        damageEffect.color = new Color(damageEffect.color.r, damageEffect.color.g, damageEffect.color.b,
            damageAlpha);
    }

    // Updating of the Statistics of the player
    // public void UpdatePlayerStats(int currentHealth, int level, int upgradePoints)
    // {
    //     if (healthText != null)
    //     {
    //         healthText.text = "Health: " + currentHealth;
    //     }
    //
    //     if (levelText != null)
    //     {
    //         levelText.text = "Level: " + level;
    //     }
    //
    //     if (upgradePointsText != null)
    //     {
    //         upgradePointsText.text = "Upgrade Points: " + upgradePoints;
    //     }
    // }
}