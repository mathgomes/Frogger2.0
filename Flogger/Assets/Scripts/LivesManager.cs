using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour {
    Text text;
    GameObject player;
    
    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        text.text = "Vidas: ";
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        text.text = "Vidas: " + player.GetComponent<PlayerController>().vidas;
    }
}
