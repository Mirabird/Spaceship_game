using UnityEngine;
using UnityEngine.UI;
public class Pickup : MonoBehaviour
{
    public int coins = 0; 
    public GameObject pickupEffect;
    public Text scoreText;
    void Start()
    {
        if (scoreText != null)
        {
            scoreText.text = "SCORE: 0";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            other.GetComponent<Collider>().enabled = false;
            if (pickupEffect != null)
                {
                    Instantiate(pickupEffect, transform.position, transform.rotation);
                }
            Destroy(other.gameObject);
            coins++;
            if (scoreText != null)
            {
                scoreText.text = "SCORE:" + coins; 
            }
        }
    }
}
