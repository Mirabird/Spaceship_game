using UnityEngine;
public class Turret : MonoBehaviour
{
    public Transform player;           // Ссылка на игрока
    public GameObject projectilePrefab; // Префаб снаряда
    public Transform firePoint;        // Точка, откуда будут вылетать снаряды
    public float fireRate = 2f;        // Скорость стрельбы турели
    private float fireCooldown;        // Время для перезарядки

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        // Если турель может стрелять, то стреляем
        if (fireCooldown <= 0f)
        {
            FireAtPlayer();
            fireCooldown = 1f / fireRate; // Перезарядка
        }
    }

    // Функция, которая вызывает создание снаряда и его движение
    void FireAtPlayer()
    {
        if (player != null)
        {
            // Создаем снаряд и направляем его в сторону игрока
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Vector3 direction = (player.position - firePoint.position).normalized;
            projectile.GetComponent<Rigidbody>().velocity = direction * 10f; // скорость снаряда
        }
    }
}