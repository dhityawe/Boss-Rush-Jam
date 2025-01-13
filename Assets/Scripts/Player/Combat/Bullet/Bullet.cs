using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BulletPool bulletPool;

    public void SetPool(BulletPool pool)
    {
        bulletPool = pool;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object implements the IDamageable interface
        IDamageable target = collision.GetComponent<IDamageable>();
        if (target != null)
        {
            target.TakeDamage(1); // Apply 1 damage (adjust as needed)
        }

        // Return the bullet to the pool
        bulletPool.ReturnBullet(gameObject);
    }
}
