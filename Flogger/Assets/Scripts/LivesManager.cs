using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour {
    Text text;
    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        text.text = "Vidas: 5";
    }
	
	// Update is called once per frame
	void Update () {
		// Mudanças nas vidas aqui
	}
}
