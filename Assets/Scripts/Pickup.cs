using UnityEngine;
using UnityEngine.UI;
public class Pickup : MonoBehaviour
{
    public int coins = 0;
    public GameObject pickupEffect;
    public Text scoreText;
    private void Start()
    {
        if (scoreText != null)
        {
            scoreText.text = "SCORE: 0";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            AudioManager.instance.PlaySfx(0);
            other.GetComponent<Collider>().enabled = false;
            
            if (pickupEffect != null)
            {
                Instantiate(pickupEffect, transform.position, transform.rotation);
            }
            Destroy(other.gameObject);
            coins++;
            
            PlayerStats.instance.AddUpgradePoints(1); 

            if (scoreText != null)
            {
                scoreText.text = "SCORE: " + coins;
            }
        }
    }
}