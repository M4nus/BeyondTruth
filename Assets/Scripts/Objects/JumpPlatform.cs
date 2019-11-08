using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    private PlayerMovementTest _playerMovement;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        _playerMovement = collision.gameObject.GetComponent<PlayerMovementTest>();
        _playerMovement.jumpVelocity *= 2;
        Debug.Log(_playerMovement.jumpVelocity);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _playerMovement.jumpVelocity /= 2;
        Debug.Log(_playerMovement.jumpVelocity);
        _playerMovement = null;
        
    }
}