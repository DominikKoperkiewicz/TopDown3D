using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IWeapon {
    [field: SerializeField] public WeaponSO weaponSO { get; set; }
    [SerializeField] private int damage = 12;
    [SerializeField] private float shootCooldown = 1.5f;
    [SerializeField] private float bulletSpeed = 16.0f;
    [SerializeField] private float bulletLifeTime = 3.0f;
    private float shootTimer = 0.0f;
    [SerializeField] private Transform shootingPoint;

    public void Shoot() {

        if (shootTimer < shootCooldown) { return; }
        
        shootTimer = 0;
        Bullet bullet = BulletPool.Instance.GetBullet();
        bullet.SetBulletProperties(shootingPoint.position, shootingPoint.rotation, transform.forward, bulletSpeed, bulletLifeTime, damage);
    }
    
    private void Awake() {
        shootTimer = shootCooldown;
    }

    private void Update() {
        shootTimer += Time.deltaTime;
    }
}
