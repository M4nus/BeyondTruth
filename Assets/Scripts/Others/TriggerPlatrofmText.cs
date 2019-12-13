using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerPlatrofmText : MonoBehaviour
{
    private bool _flag;


    private void Start()
    {
        _flag = false;
    }

    private void Update()
    {

        gameObject.GetComponent<TextMeshProUGUI>().text = "State = " + _flag;
      
    }
    public void Toggle()
    {
        _flag = !_flag;
    }
}
