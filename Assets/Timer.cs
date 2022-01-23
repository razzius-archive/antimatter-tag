using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public float timeValue = 0f;
    public TMP_Text timeText;
    public bool stopped = false;
    
    // Start is called before the first frame update
    void Start() {}
    
    public void Stop() {
    	stopped = true;
    }

    // Update is called once per frame
    void Update()
    {
    	if (stopped) {
    	    timeText.text = string.Format("You scored {0}!", Mathf.FloorToInt(timeValue));
    	    return;
    	}
        timeValue += Time.deltaTime;
        timeText.text = string.Format("{0}", Mathf.FloorToInt(timeValue));
    }
}
