using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player Instance { get; private set; } 
    private IWeapon weapon;
    [SerializeField] private Transform grabPoint;
    [SerializeField] private GameInput gameInput;

    public void SetWeapon(WeaponSO weaponSO) {
        if (weaponSO == null) { this.weapon = null; return; }

        DestroyAllChildren(grabPoint);
        Transform weaponGameObject = Instantiate(weaponSO.prefab, grabPoint.position, grabPoint.rotation, grabPoint);
        PlayerUI.Instance.SetWeaponImage(weaponSO.sprite);
        this.weapon = weaponGameObject.gameObject.GetComponent<IWeapon>();
    }

    private void Awake() {
        if (Instance != null) {
            Debug.LogError("Multiple instances of Player!");
        }
        Instance = this;
    }

    private void Update() {
        if (gameInput.IsFireInputDown() && weapon != null) {
            weapon.Shoot();
        }
    }

    private void DestroyAllChildren(Transform transform) {
        for (int i = transform.childCount; i > 0; i--) {
            Destroy(transform.GetChild(0).gameObject);
        }
    }

}