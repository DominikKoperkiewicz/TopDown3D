using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour, IWeapon {

    [field: SerializeField] public WeaponSO weaponSO { get; set; }
    [SerializeField] private int damage = 3;
    [SerializeField] private float shootCooldown = 0.3f;
    [SerializeField] private float bulletSpeed = 18.0f;
    [SerializeField] private float bulletLifeTime = 3.0f;
    [SerializeField] private float bulletSpread = 1.0f;
    private float shootTimer = 0.0f;
    [SerializeField] private Transform shootingPoint;

    public void Shoot() {

        if (shootTimer < shootCooldown) { return; }
        
        shootTimer = 0;
        Bullet bullet = BulletPool.Instance.GetBullet();
        var rotationAngle = Random.Range(-bulletSpread, bulletSpread);
        Vector3 bulletDirection = Quaternion.AngleAxis(rotationAngle, Vector3.up) * transform.forward;
        bullet.SetBulletProperties(shootingPoint.position, shootingPoint.rotation, bulletDirection, bulletSpeed, bulletLifeTime, damage);
    }

    private void Awake() {
        shootTimer = shootCooldown;
    }

    private void Update() {
        shootTimer += Time.deltaTime;
    }
}
