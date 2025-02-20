using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform player;           // Player
    public GameObject projectilePrefab; // Projectile
    public Transform firePoint;        // FirePoint
    public float fireRate = 10f;        // FireRate
    public float rotationSpeed = 30f;   // RotationSpeed
    
    private float fireCooldown;        // FireCooldown
    void Update()
    {
        // Turn the turret towards the player
        if (player != null)
        {
            // the direction of the player
            Vector3 direction = player.position - transform.position;
            direction.y = 0f;
            
            // Defining the target rotation
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        fireCooldown -= Time.deltaTime;
        
        if (fireCooldown <= 0f)
        {
            FireAtPlayer();
            fireCooldown = 1f / fireRate;
        }
    }
    // function for shooting at the player
    void FireAtPlayer()
    {
        if (player != null)
        {
            // Creating a projectile from the firePoint position with its current rotation
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Vector3 direction = (player.position - firePoint.position).normalized;
            projectile.GetComponent<Rigidbody>().velocity = direction * 10f;
        }
    }
}