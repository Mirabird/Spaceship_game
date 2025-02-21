using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform player;           // Player
    public GameObject projectilePrefab; // Projectile
    public Transform firePoint;        // FirePoint
    public float fireRate = 3f;        // FireRate
    public float rotationSpeed = 60f;   // RotationSpeed
    
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
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            projectile.transform.parent = null;
            
            Rigidbody playerRb = player.GetComponent<Rigidbody>();
            
            Vector3 shotDirection = (player.position - firePoint.position).normalized;
            
            if (playerRb != null)
            {
                float projectileSpeed = 20f; 
                float distance = Vector3.Distance(firePoint.position, player.position);
                float timeToTarget = distance / projectileSpeed; 
                
                Vector3 futurePosition = player.position + playerRb.velocity * timeToTarget;
                shotDirection = (futurePosition - firePoint.position).normalized;
            }
            
            projectile.transform.forward = shotDirection;
            
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.velocity = shotDirection * 20f;
        }
    }
}