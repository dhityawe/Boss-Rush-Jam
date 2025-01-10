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
        IBulletTarget target = collision.GetComponent<IBulletTarget>();
        if (target != null)
        {
            target.OnBulletHit(gameObject); // Notify target of the hit
        }

        // Return bullet to pool
        bulletPool.ReturnBullet(gameObject);
    }
}
