using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour {

    public static BulletPool Instance { get; private set; } 
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize = 20;
    private Queue<Bullet> bulletPool;

    private void Awake() {
        if(Instance != null) {
            Debug.LogError("Multiple instances of BulletPool!");
        }
        Instance = this;
    }

    void Start()
    {
        bulletPool = new Queue<Bullet>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bulletInstance = Instantiate(bulletPrefab);
            bulletInstance.SetActive(false);
            bulletPool.Enqueue(bulletInstance.GetComponent<Bullet>());
        }
    }

    public Bullet GetBullet()
    {
        if (bulletPool.Count > 0)
        {
            Bullet bullet = bulletPool.Dequeue();
            bullet.gameObject.SetActive(true);
            return bullet;
        }
        else
        {
            GameObject bulletInstance = Instantiate(bulletPrefab);
            bulletInstance.SetActive(true);
            Bullet bullet = bulletInstance.GetComponent<Bullet>();
            return bullet;
        }
    }

    public void ReturnBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}