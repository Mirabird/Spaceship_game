using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            DontDestroyOnLoad(gameObject); 
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
            Debug.LogError("Pickup script not found in the scene! Make sure it's in the scene and active.");
        }
    
        if (gameOverscreen == null)
        {
            Debug.LogError("GameOverScreen is not assigned in the inspector! Assign it to GameManager.");
        }
    }
    
    public void ShowGameOver()
    {
        if (_pickupScript == null)
        {
            _pickupScript = FindObjectOfType<Pickup>(); 
        }

        if (_pickupScript != null && gameOverscreen != null)
        {
            gameOverscreen.SetActive(true);
            gameOverScoreText.text = "SCORE: " + _pickupScript.coins;
            Time.timeScale = 0f;
        }
        else
        {
            Debug.LogError($"Cannot show game over screen because Pickup ({_pickupScript}) or GameOverScreen ({gameOverscreen}) is null!");
        }
    }
    public void RestartButton()
    {
        if (PlayerStats.instance != null)
        {
            PlayerStats.instance.ResetStats();
        }
        
        UIController.instance.UpdateUI();
        
        gameOverscreen.SetActive(false);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        Time.timeScale = 1f;
    }

}