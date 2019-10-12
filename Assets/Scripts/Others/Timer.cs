using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float time;
    private TextMeshProUGUI timer;
    public float currentTime;
                                                      
    void Start()
    {
        timer = GetComponent<TextMeshProUGUI>();
        timer.text = "" + time;
        currentTime = time;
    }
                                        
    void Update()
    {                                     
        currentTime -= Time.deltaTime;
        timer.text = "" + Mathf.Ceil(currentTime);
        TimeOut();
    }

    void TimeOut()
    {
        if(Mathf.Ceil(currentTime) < 0)
        {         
            MusicManager.sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("Death");
            MusicManager.instance.FadeOutMusic();
        }
    }
}
