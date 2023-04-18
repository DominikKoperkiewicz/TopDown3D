using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI Instance { get; private set; } 
    [SerializeField] private Image weaponImage;
    private WeaponSO playerWeaponSO;

    public void SetWeaponImage(Sprite sprite) {
        weaponImage.sprite = sprite;
    }
    
    private void Awake() {
        if(Instance != null) {
            Debug.LogError("Multiple instances of PlayerUI!");
        }
        Instance = this;
    }
}
