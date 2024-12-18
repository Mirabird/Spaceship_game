using UnityEngine;
public class LevelMechanics : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.ShowGameOver();
            Debug.Log("Level is restarting");
        }
    }
}
