using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager instance;
    public Particle[] particles;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        foreach(Particle p in particles)
        {
            p.particle = gameObject.GetComponent<ParticleSystem>();
            p.particle.name = p.name;
        }
    }

    public void Play(string name)
    {
        Particle p = Array.Find(particles, particle => particle.name == name);
        var em = p.particle.emission;
        em.enabled = true;
    }

    public void Stop(string name)
    {
        Particle p = Array.Find(particles, particle => particle.name == name);
        var em = p.particle.emission;
        em.enabled = false;
    }
}
