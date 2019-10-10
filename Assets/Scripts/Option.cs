using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    public GameObject portal;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.instance.Play("OptionSelect");
        gameObject.SetActive(false);
        portal.SetActive(true);
    }
}
