using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOverscreen;
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
    public void ShowGameOver()
    {
        gameOverscreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
