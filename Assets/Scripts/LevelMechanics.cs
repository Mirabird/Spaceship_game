using UnityEngine;
public class LevelMechanics : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //restart level
            Debug.Log("Level is restarting");
        }
    }
}
