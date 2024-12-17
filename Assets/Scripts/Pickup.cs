using UnityEngine;
using UnityEngine.UI;
public class Pickup : MonoBehaviour
{
    public int coins = 0; 
    public GameObject pickupEffect;
    public Text scoreText;
    void Start()
    {
        scoreText.text = "SCORE: 0";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Instantiate(pickupEffect, transform.position, transform.rotation);
            coins++;
            scoreText.text = "SCORE:" + coins;
            Destroy(other.gameObject);
        }
    }
}
