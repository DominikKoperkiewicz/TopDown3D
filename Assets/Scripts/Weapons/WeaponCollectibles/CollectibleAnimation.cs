using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleAnimation : MonoBehaviour {
    
    [SerializeField] private float rotationSpeed = 120.0f;

    private void Update() {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

}
