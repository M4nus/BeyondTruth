using System.Collections;
using System.Collections.Generic;
using UnityEngine;           
using UnityEngine.SceneManagement;

public class RetryPortal : MonoBehaviour
{                             
    public Animator fader;

    private void Start()
    {
        if(fader == null)
        {                               
            fader = GameObject.Find("CanvasFader").GetComponentInChildren<Animator>();
        }
        else
        {                                
            fader = GetComponentInChildren<Animator>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.instance.Play("Portal");
        if(fader == null)
        {                               
            fader = GameObject.Find("CanvasFader").GetComponentInChildren<Animator>();
        }
        else
        {                               
            fader = GetComponentInChildren<Animator>();
        }
        if(fader != null)
        {
            fader.SetBool("Fade", true);
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;
        SceneManager.LoadScene(MusicManager.sceneName);
    }
}
