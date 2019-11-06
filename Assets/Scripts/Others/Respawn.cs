using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField]
    private Transform _respawnPoint;
    
    public GameObject particleEmitter;
    public GameObject Minus;
    public GameObject Timer;
    public CameraShake camShake;
    public ParticleSystem deathParticles;
    public Animator MinusScore;
    public Timer time;
    public bool deathParticlesBlockade = false;

    private void Start()
    {           
        camShake = GameObject.FindObjectOfType<Camera>().GetComponent<CameraShake>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {                                           
        MinusScore = Minus.GetComponent<Animator>();
        MinusScore.SetBool("LaunchMinus", true);
        time = Timer.GetComponent<Timer>();
        time.currentTime--;                       
        if(camShake.enabled)
            StartCoroutine(camShake.Shake(0.5f, 0.3f)); 
        deathParticles = particleEmitter.GetComponent<ParticleSystem>();
        if(particleEmitter.gameObject.active)
        {
            deathParticles.transform.position = collision.transform.position;
            deathParticles.Emit(10);  
        }
        collision.gameObject.transform.position = _respawnPoint.position;
        AudioManager.instance.Play("Zip");
        StartCoroutine(WaitForMinus());
    }

    public IEnumerator WaitForMinus()
    {
        yield return new WaitForSeconds(0.3f);
        MinusScore.SetBool("LaunchMinus", false);
    }
}
