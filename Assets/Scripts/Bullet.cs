using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private int damage;
    private float velocity;
    private float lifeTime;
    private Vector3 direction;
    [SerializeField] private TrailRenderer trailRenderer;
    
    private void Update() {
        BulletMovement();
        LifeUpdate();
    }

    public void SetBulletProperties(Vector3 position, Quaternion rotation, Vector3 direction, float velocity, float lifeTime, int damage) {
        transform.position = position;
        transform.rotation = rotation;
        this.direction = direction;
        this.velocity = velocity;
        this.lifeTime = lifeTime;
        this.damage = damage;
        ClearTrail();
    }

    private void BulletMovement() {
        transform.position += direction * velocity * Time.deltaTime;
    }

    private void LifeUpdate() {
        lifeTime -= Time.deltaTime;
        if(lifeTime < 0) {
            BulletPool.Instance.ReturnBullet(this);
        }
    }

    private void ClearTrail() {
        trailRenderer.Clear();
    }
}
