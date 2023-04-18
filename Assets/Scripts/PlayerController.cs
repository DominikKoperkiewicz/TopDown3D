using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float playerSpeed = 1f;
    [SerializeField] private float playerMaxVelocity = 6f;
    [SerializeField] private float decelerationRate = 0.9f;
    [SerializeField] private GameInput gameInput;
    private Vector2 playerVelocity;

    private void Update() {
        PlayerMovement();
        LookAtCursor();
    }

    private void PlayerMovement() {

        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        playerVelocity += inputVector * playerSpeed;
        playerVelocity *= decelerationRate;

        if(playerVelocity.magnitude > playerMaxVelocity) {
            playerVelocity = playerVelocity.normalized * playerMaxVelocity;
        }

        Vector3 movementVector = new Vector3(playerVelocity.x, 0.0f, playerVelocity.y) * Time.deltaTime;
        transform.position += movementVector;
    }

    private void LookAtCursor() {
        float rotationSpeed = 9.0f;
        Vector3 lookDirection = gameInput.GetMouseRaycastPosition() - transform.position;
        lookDirection.y = 0.0f;
        transform.forward = Vector3.Slerp(transform.forward, lookDirection, Time.deltaTime * rotationSpeed);
    }

}