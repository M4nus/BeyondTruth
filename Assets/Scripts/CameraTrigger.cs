using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public GameObject camera;
    public Animator cameraAnim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cameraAnim = camera.GetComponent<Animator>();
        cameraAnim.SetTrigger("CameraMove");
    }
}
