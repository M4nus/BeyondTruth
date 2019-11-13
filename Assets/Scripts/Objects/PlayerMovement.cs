using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	//For shaking MainCamera when player hits ground or screen border
	[Header("Objects")]
	public CameraShake camShake;

	
    [SerializeField]
    private Rigidbody2D _rb;

    [Range(0, 2000)]
    public float playerSpeed = 100f;
    public float jumpForce = 100f;
    public bool grounded = true;
    public ParticleSystem hitParticles;

	

    void Start()
    {
        _rb = this.gameObject.GetComponent<Rigidbody2D>();
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
        _rb.velocity = new Vector2(direction * playerSpeed * Time.deltaTime, _rb.velocity.y);
    }

    void Jump()
    {
        if(grounded)
        {
            _rb.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
            grounded = true;
        if(camShake.enabled)
            StartCoroutine(camShake.Shake(0.1f, 0.2f));    
        hitParticles = GetComponentInChildren<ParticleSystem>();
        hitParticles.Emit(5);          
        AudioManager.instance.Play("HitSound");
    }
}
