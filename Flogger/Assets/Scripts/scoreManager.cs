using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour {
    public Text text;
    public string format = "SCORE: {0}";

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
		text.text = string.Format(format, PlayerInfoGlobal.pontos);
    }
}
