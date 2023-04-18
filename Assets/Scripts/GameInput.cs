using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour {
    
    private PlayerInputActions playerInputActions;
    [SerializeField] private LayerMask raycastLayerMask;

    private void Awake() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }
    public Vector2 GetMovementVectorNormalized() {
        
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }

    public Vector3 GetMouseRaycastPosition() {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 pointOnSurface = Vector3.zero;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, raycastLayerMask)) {
            pointOnSurface = hit.point;
        }

        return pointOnSurface;
    }

    public bool IsFireInputDown() {
        bool fireInput = playerInputActions.Player.Fire.IsPressed();
        return fireInput;
    }
}