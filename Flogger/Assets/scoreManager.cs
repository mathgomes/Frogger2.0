using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour {
    public Text text;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Score: ";
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + player.GetComponent<PlayerController>().pontos;
    }
}
