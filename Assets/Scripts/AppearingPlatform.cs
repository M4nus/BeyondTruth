using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearingPlatform : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();       
    }   

    void OnCollisionEnter2D(Collision2D collision)
    {                      
        anim.SetBool("animate", true);
    }              
}
