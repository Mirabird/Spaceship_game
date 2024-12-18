using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOverscreen;
    
    private Pickup _pickupScript;
    public Text gameOverScoreText;
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
    void Start()
    {
        _pickupScript = FindObjectOfType<Pickup>(); 
        
        if (_pickupScript == null)
        {
            Debug.LogError("Pickup script not found in the scene!");
        }
        
        if (gameOverscreen == null)
        {
            Debug.LogError("GameOverScreen is not assigned in the inspector!");
        }

        if (gameOverScoreText == null)
        {
            Debug.LogError("GameOverScoreText is not assigned in the inspector!");
        }
    }
    public void ShowGameOver()
    {
        if (_pickupScript != null)
        {
            gameOverscreen.SetActive(true);
            gameOverScoreText.text = "SCORE: " + _pickupScript.coins;
            Time.timeScale = 0f;
        }
        else
        {
            Debug.LogError("Cannot show game over screen because Pickup is null!");
        }
    }
}
