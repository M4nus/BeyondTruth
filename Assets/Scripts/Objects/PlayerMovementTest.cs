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
        _rigBody = player.GetComponent<Rigidbody2D>();
		camShake = GameObject.FindObjectOfType<Camera>().GetComponent<CameraShake>();
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
		
		if (_rigBody.velocity.y < 0f)
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
