using UnityEngine;
public class Pickup : MonoBehaviour
{
    public int coins = 0; 
    public GameObject pickupEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Instantiate(pickupEffect, transform.position, transform.rotation);
            coins++;
            Destroy(other.gameObject);
        }
    }
}
