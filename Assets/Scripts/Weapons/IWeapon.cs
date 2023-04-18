
using UnityEngine;

public interface IWeapon {

    WeaponSO weaponSO { get; set; }

    void Shoot();
}