using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    private Rigidbody2D _rb;

    [Range(0, 2000)]
    public float playerSpeed = 100f;
    public float jumpForce = 100f;
    public bool grounded = true;
    public ParticleSystem hitParticles;
    public CameraShake camShake;

    void Start()
    {
        _rb = _player.GetComponent<Rigidbody2D>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        camShake = GameObject.FindObjectOfType<Camera>().GetComponent<CameraShake>();
    }
                                      
    void Update()
    {                                           
        Move();
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
            grounded = false;
        }
        CheckVelocity();
    }

    void CheckVelocity()
    {
        if(_rb.velocity.x > 40)
            _rb.velocity = new Vector2(40f, _rb.velocity.y);
        if(_rb.velocity.x < -40)
            _rb.velocity = new Vector2(-40f, _rb.velocity.y);
        if(_rb.velocity.y > 60)
            _rb.velocity = new Vector2(_rb.velocity.x, 60f);

    }

    void Move()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        if(_rb.gravityScale > 0)
            _rb.velocity = new Vector2(direction * playerSpeed * Time.deltaTime, _rb.velocity.y);
        else
            _rb.velocity = new Vector2(-direction * playerSpeed * Time.deltaTime, _rb.velocity.y);
    }

    void Jump()
    {
        if(grounded)
        {
            _rb.gravityScale = -_rb.gravityScale;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        hitParticles.Emit(5);
        if(collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
            grounded = true;
        StartCoroutine(camShake.Shake(0.1f, 0.2f));
    }
}
