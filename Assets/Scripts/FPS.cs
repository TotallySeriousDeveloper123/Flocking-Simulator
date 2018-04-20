using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour {
    private float fps;
    float count = 0;
    float startTime;
    public Text framecountertext;
	void Start ()
    {
       
	}
	
	
	void Update ()
    {
        startTime = Time.time;

        getFPS();
	}

    ///simplistic Frame counter
    float  getFPS()
    {
        count++;
        fps = (int)(count / startTime);
        SetText();
        return fps;
        
    }

    // sets the UI
    void SetText()
    {
        framecountertext.text = "FPS " + fps.ToString();

    }
}
