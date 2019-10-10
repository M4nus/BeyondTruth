using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTroll : MonoBehaviour
{
    public GameObject portal;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        portal.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
