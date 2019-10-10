using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiePlatform : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();       
    }   

    void OnTriggerEnter2D(Collider2D collision)
    {                      
        anim.SetBool("animate", true);
    }              
}
