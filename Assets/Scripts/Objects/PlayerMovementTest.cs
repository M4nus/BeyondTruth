using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerMovementTest : MonoBehaviour
{
	Rigidbody2D _rigBody;
	public ParticleSystem hitParticles;

	[Header("Options:")]
	[Range(0f, 300f)]
	public float playerSpeed = 150f;
	[Range(0, 1000f)]
	public float jumpVelocity = 650f;
	[Range(0, 10f)]
	public float fallMultiplier = 3f;
	[Range(0, 25f)]
	public float lowJumpMultiplier = 15f;
	[HideInInspector]
	public bool isOnGround = true;

	
	void Awake()
    {
        _rigBody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
		float _dirX = Input.GetAxisRaw("Horizontal") * playerSpeed * Time.deltaTime * 10f;
		_rigBody.velocity = new Vector2(_dirX, _rigBody.velocity.y);
    }

	void FixedUpdate()
	{
        if (Input.GetButtonDown("Jump") && isOnGround == true)
		{
			_rigBody.AddForce(new Vector2(0f, jumpVelocity * 5f));
			isOnGround = false;
		}
		
		if (_rigBody.velocity.y < 0f && isOnGround == false)
		{
            _rigBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
		}
		if (_rigBody.velocity.y > 0f && !Input.GetButton("Jump") && isOnGround == false)
		{
			_rigBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
		}
	}

	void OnCollisionEnter2D(Collision2D collision) 
	{
        Debug.Log(collision.relativeVelocity.magnitude);
        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
		{
		 	isOnGround = true;
            if (collision.relativeVelocity.magnitude > 0 && collision.relativeVelocity.magnitude <= 60)
            {
                CameraShaker.Instance.ShakeOnce(Random.Range(1.1f, 1.5f), 1f, 0.2f, 0.2f, new Vector2(1, 2), new Vector2(1, 2));
            }
            else if (collision.relativeVelocity.magnitude > 60 && collision.relativeVelocity.magnitude <= 80)
            {
                CameraShaker.Instance.ShakeOnce(Random.Range(1.6f, 2.1f), 1f, 0.2f, 0.2f, new Vector2(1.2f, 2.2f), new Vector2(1.2f, 2.2f));
            }
            else if (collision.relativeVelocity.magnitude > 80)
            {
                CameraShaker.Instance.ShakeOnce(Random.Range(2.2f, 2.7f), 1f, 0.2f, 0.2f, new Vector2(1.4f, 2.4f), new Vector2(1.4f, 2.4f));
            }
            
        }
        
        hitParticles = GetComponentInChildren<ParticleSystem>();
        hitParticles.Emit(5); 
		AudioManager.instance.Play("HitSound");
	}
}
