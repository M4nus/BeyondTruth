using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTest : MonoBehaviour
{
	[Header("Objects:")]
	public CameraShake camShake;
	public GameObject player;
	Rigidbody2D _rigBody;
	public ParticleSystem hitParticles;

	[Header("Options:")]
	[Range(0f, 400f)]
	public float playerSpeed = 250f;
	[Range(0, 50f)]
	public float jumpVelocity = 6f;
	[Range(0, 10f)]
	public float fallMultiplier = 2.5f;
	[Range(0, 10f)]
	public float lowJumpMultiplier = 2f;
	[HideInInspector]
	public bool isOnGround = true;

	
	void Awake()
    {
        _rigBody = player.GetComponent<Rigidbody2D>();
		camShake = GameObject.FindObjectOfType<Camera>().GetComponent<CameraShake>();
    }

    void Update()
    {
		float _dirX = Input.GetAxisRaw("Horizontal") * playerSpeed * Time.deltaTime * 10f;
		float _dirY = Input.GetAxisRaw("Vertical") * jumpVelocity * Time.deltaTime * 50f;
		
		_rigBody.velocity = new Vector2(_dirX, _rigBody.velocity.y);
		if (/*Input.GetButton("Jump") && */Input.GetAxis("Vertical") != 0 && isOnGround == true)
		{
			_rigBody.velocity = new Vector2(_rigBody.velocity.x, Mathf.Abs(_dirY));
			//_rigBody.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpVelocity), ForceMode2D.Impulse);
			isOnGround = false;
		}
				
		if (_rigBody.velocity.y < 0f)
		{
			_rigBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime * 2;
		}
		else if (_rigBody.velocity.y > 0f && !Input.GetButton("Jump"))
		{
			_rigBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
		}

		
    }

	void OnCollisionEnter2D(Collision2D collision) 
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
		{
		 	isOnGround = true;
		}
		if (camShake.enabled == true)
		{
		 	StartCoroutine(camShake.Shake(0.1f, 0.2f));
		}
		hitParticles = GetComponentInChildren<ParticleSystem>();
        hitParticles.Emit(5); 
		AudioManager.instance.Play("HitSound");
	}
}
