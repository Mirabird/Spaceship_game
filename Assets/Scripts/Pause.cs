using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    public GameObject pauseScreen;
    public bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }
    public void PauseUnpause()
    {
        if (isPaused)
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
            AudioListener.pause = false;
        }
        else
        {
            isPaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
            AudioListener.pause = true; 
        }
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        AudioListener.pause = false;

        if (GameManager.instance != null && GameManager.instance.gameOverscreen != null)
        {
            GameManager.instance.gameOverscreen.SetActive(false);
        }
    }
    public void RestartButton()
    {
        if (PlayerStats.instance != null)
        {
            PlayerStats.instance.ResetStats();
        }

        if (PlayerHealth.instance != null)
        {
            PlayerHealth.instance.UpdateHealth(); 
        }

        UIController.instance.UpdateUI();
        
        if (GameManager.instance != null && GameManager.instance.gameOverscreen != null)
        {
            GameManager.instance.gameOverscreen.SetActive(false);
        }
    
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    
        Time.timeScale = 1f;
    } 


}