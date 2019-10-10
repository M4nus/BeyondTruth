using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutTrigger : MonoBehaviour
{               
    private void OnCollisionEnter2D(Collision2D collision)
    {
        MusicManager.instance.FadeOutMusic();
    }
}
