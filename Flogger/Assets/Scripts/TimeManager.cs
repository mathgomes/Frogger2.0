using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {
    Text text;
    public float time;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        time = 128;
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        var minutes = Mathf.Floor(time / 60); //Divide the guiTime by sixty to get the minutes.
        var seconds = time % 60;//Use the euclidean division for the seconds.


        //update the label value
        text.text = string.Format("Tempo: {0:00} : {1:00}", minutes, seconds);
    }

    private object floor(float v)
    {
        throw new NotImplementedException();
    }
}
