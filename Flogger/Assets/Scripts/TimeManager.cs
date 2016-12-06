using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {
    public Text text;
    public float time;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        var minutes = Mathf.Floor(time / 60); //Divide por 60 para pegar os minutos
        var seconds = time % 60;    //Os segundos são o resto


        //Faz update na label
        text.text = string.Format("Tempo: {0:00} : {1:00}", minutes, seconds);

        if( time <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

}
