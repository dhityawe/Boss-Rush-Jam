using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize = 20;

    private Queue<GameObject> bulletPool = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bullet.GetComponent<Bullet>().SetPool(this); // Set the pool reference
            bulletPool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet(Vector3 position, Quaternion rotation)
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue();
            bullet.transform.position = position;
            bullet.transform.rotation = rotation;
            bullet.SetActive(true);
            return bullet;
        }

        Debug.LogWarning("Bullet pool is empty!");
        return null;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}
