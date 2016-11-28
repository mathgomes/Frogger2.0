using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    void Start() {
        transform.Translate(-8, -1, 0);

    }
    void Update() { 

        transform.Translate(Time.deltaTime,0,0);
    }
}
