using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearingPlatform : MonoBehaviour
{
    private Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();       
    }   

    void OnCollisionEnter2D(Collision2D collision)
    {                      
        _anim.SetBool("animate", true);
    }              
}
