using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPlatform : MonoBehaviour
{
    public GameObject platformLie;
    public GameObject platformNormal;
    public GameObject otherCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {                                                    
        platformLie.transform.position = gameObject.transform.position;
        platformNormal.transform.position = otherCollider.transform.position;
        gameObject.SetActive(false);
        otherCollider.SetActive(false);
    }

}
