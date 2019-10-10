using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerText : MonoBehaviour
{
    public int triggerNumber;
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim = anim.gameObject.GetComponent<Animator>(); 
        anim.SetTrigger("Text" + triggerNumber);
    }
}
