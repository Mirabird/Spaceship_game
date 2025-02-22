using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public string levelName;
    public string creditsName;
    public void StartGame()
    {
        if (GameManager.instance != null && GameManager.instance.gameOverscreen != null)
        {
            GameManager.instance.gameOverscreen.SetActive(false);
        }
    
        SceneManager.LoadScene(levelName);
    }
    public void CreditsScene()
    {
        SceneManager.LoadScene(creditsName);
    }
    public void LeaveGame()
    {
        Application.Quit();
        Debug.Log("Leaving the game");
    }
}
