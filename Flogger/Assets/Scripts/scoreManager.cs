using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour {
    public Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Score: ";
    }

    // Update is called once per frame
    void Update()
    {
		text.text = "Score: " + PlayerInfoGlobal.pontos;
    }
}
