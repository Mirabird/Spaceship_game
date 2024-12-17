using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelMechanics : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   //restart level
            Debug.Log("Level is restarting");
        }
    }
}
