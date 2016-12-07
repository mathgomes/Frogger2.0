using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour {
    public Text text;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
		text.text = "Vidas: ";
    }
	
	// Update is called once per frame
	void Update () {
		text.text = "Vidas: " + PlayerInfoGlobal.vidas;
    }
}
