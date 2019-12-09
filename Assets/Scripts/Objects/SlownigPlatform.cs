using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlownigPlatform : MonoBehaviour
{
    private PlayerMovementTest _playerMovement;
    public float divisor;

    private void OnCollisionEnter2D(Collision2D other) {
        _playerMovement = other.gameObject.GetComponent<PlayerMovementTest>();
        _playerMovement.playerSpeed /= divisor;
        _playerMovement.jumpVelocity /= divisor;
    }

    private void OnCollisionExit2D(Collision2D other) {
        _playerMovement.playerSpeed *= divisor;
        _playerMovement.jumpVelocity *= divisor;
        _playerMovement = null;
    }
}
