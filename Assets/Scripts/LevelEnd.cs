using UnityEngine.SceneManagement;
using UnityEngine;
public class LevelEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           // PlayerStats.instance.IncreaseLevel();  
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene + 1); 
        }
    }
}
