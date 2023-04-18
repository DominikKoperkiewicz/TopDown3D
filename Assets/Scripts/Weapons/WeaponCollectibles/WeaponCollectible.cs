using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponCollectible : MonoBehaviour {

    [SerializeField] private WeaponSO weaponSO;
    [SerializeField] private Image imageVisual;

    public void Collect() {
        Player.Instance.SetWeapon(weaponSO);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {
            Collect();
        }
    }
    
    private void Awake() {
        imageVisual.sprite = weaponSO.sprite;
    }

}
