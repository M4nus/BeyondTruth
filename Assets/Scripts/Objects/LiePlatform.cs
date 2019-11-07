using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiePlatform : MonoBehaviour
{
    private Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();       
    }   

    void OnTriggerEnter2D(Collider2D collision)
    {                      
        _anim.SetBool("animate", true);
    }              
}
