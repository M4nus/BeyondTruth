using System.Collections;          
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyStory : MonoBehaviour
{           
    public Animator fader;
    public GameObject puller;
                                                       
    void Start()
    {
        fader = fader.gameObject.GetComponent<Animator>();
        StartCoroutine(PlayPuller());
    }    

    IEnumerator PlayPuller()
    {
        yield return new WaitForSeconds(9f);
        puller.SetActive(true);
        yield return new WaitForSeconds(4f);
        yield return StartCoroutine(SetTrigger());
    }

    IEnumerator SetTrigger()
    {
        fader.SetBool("Fade", true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("People");
    }
}
