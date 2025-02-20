using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    public int damage = 10;

    // Снаряд движется в сторону игрока
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Наносим урон игроку
            collision.gameObject.GetComponent<PlayerHealth>().DealDamage();
            Destroy(gameObject);  // Уничтожить снаряд после столкновения
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);  // Уничтожить снаряд при столкновении с препятствием
        }
    }
}
