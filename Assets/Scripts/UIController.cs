using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Text healthText;
    public Text upgradePointsText;
    
    public Text damageText;  
    public Text speedText;   
    
    public Image damageEffect;
    public float damageAlpha = 0.25f;
    
    public Button upgradeHealthButton;
    public Button upgradeDamageButton;
    public Button upgradeSpeedButton;
    public Button openUpgradePanelButton;
    
    public GameObject upgradePanel;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        UpdateUI();
        
        upgradeHealthButton.onClick.AddListener(UpgradeHealth);
        upgradeDamageButton.onClick.AddListener(UpgradeDamage);
        upgradeSpeedButton.onClick.AddListener(UpgradeSpeed);
        openUpgradePanelButton.onClick.AddListener(ToggleUpgradePanel);
    }
    public void UpdateUI()
    {
        if (PlayerStats.instance == null)
        {
            Debug.LogError("PlayerStats.instance is NULL!");
            return;
        }

        if (healthText != null) healthText.text = "Health: " + PlayerStats.instance.health;
        else Debug.LogError("healthText is not assigned!");

        if (upgradePointsText != null) upgradePointsText.text = "Upgrade Points: " + PlayerStats.instance.UpgradePoints;
        else Debug.LogError("upgradePointsText is not assigned!");

        if (damageText != null) damageText.text = "Damage: " + PlayerStats.instance.damage;
        else Debug.LogError("damageText is not assigned!");

        if (speedText != null) speedText.text = "Speed: " + PlayerStats.instance.GetSpeed();
        else Debug.LogError("speedText is not assigned!");
    }

    public void UpgradeHealth()
    {
        if (PlayerStats.instance.TryUpgradeHealth())
        {
            UpdateUI(); 
        }
    }
    public void UpgradeDamage()
    {
        if (PlayerStats.instance.TryUpgradeDamage())
        {
            UpdateUI();  
        }
        
        damageText.text = "Damage: " + PlayerStats.instance.damage;
    }
    public void UpgradeSpeed()
    {
        if (PlayerStats.instance.TryUpgradeSpeed())
        {
            UpdateUI();  
        }
    }
    public void ShowDamage()
    {
        if (damageEffect != null)
        {
            StartCoroutine(FadeDamageEffect());
        }
    }

    private IEnumerator FadeDamageEffect()
    {
        float elapsedTime = 0f;
        Color originalColor = damageEffect.color;
        Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);

        while (elapsedTime < 1f)
        {
            damageEffect.color = Color.Lerp(originalColor, targetColor, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        damageEffect.color = targetColor; 
    }
    public void ToggleUpgradePanel()
    {
        upgradePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void CloseUpgradePanel()
    {
        upgradePanel.SetActive(false); 
        Time.timeScale = 1f; 
    }
}