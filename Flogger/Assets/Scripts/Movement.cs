using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	
    void Update() { 
        transform.Translate(Time.deltaTime,0,0);
    }

}
