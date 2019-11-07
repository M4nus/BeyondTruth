using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private Rigidbody2D _playerRb = null;

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
        _playerRb.gravityScale = 0.0f;
        Debug.Log(_playerRb.gravityScale);
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        _playerRb.gravityScale = 10;
        _playerRb = null;
        
    }

    private void FixedUpdate()
    {
        if(_playerRb != null) Debug.Log(_playerRb.gravityScale);
    }
}
