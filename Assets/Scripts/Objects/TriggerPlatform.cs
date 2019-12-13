using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerPlatform : MonoBehaviour
{
    public UnityEvent e;


    private void Start()
    {
        e.AddListener(Action);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        e.Invoke();
    }

    void Action()
    {
        Debug.Log("Trigger");
    }
}
